using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rbac.Entity;
using Rbac.WebAPI.Configuration;
using Rbac.Unitity;
using Rbac.Dtos;
using Rbac.IService;
using Rbac.IRepository;
using CSRedis;
using System.Threading.Tasks;

namespace Rbac.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(option=> {
                //option.Filters.Add<AuthonizationFilter>();
            }).AddJsonSetting();

            //跨域
            services.AddCors(option => {
                option.AddDefaultPolicy(build => {
                    build.AllowCredentials();
                    build.AllowAnyMethod();
                    build.AllowAnyHeader();
                    build.WithOrigins("http://localhost:8080").AllowCredentials();
                });
            });

            //services.AddHostedService<MyCustomBackService>();

            //CSRedisClient client = new CSRedisClient(Configuration["Redis:ConnectionStrings"]);
            //services.AddSingleton<CSRedisClient>(client);
            //RedisHelper.Initialization(client);

            services.AddAutoMapper(cfg => {
                cfg.AddProfile<RbacProfile>();
            });

            //EF Core的db上下文
            services.AddDbContext<RbacDbContext>(option => {
                option.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
            });

            //便于其他类库访问HTTP上下文
            services.AddHttpContextAccessor();

            services.AddHttpContext();

            //使用.net core自带的注册
            services.AddIoc();

            //JWT认证参数
            services.AddJwtBearer();

            //Swagger配置
            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IRoleRepository roleRepository)
        {
            app.UseStaticHttpContext();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "通用模块");
                c.SwaggerEndpoint("/swagger/gp/swagger.json", "登录模块");
                c.SwaggerEndpoint("/swagger/mom/swagger.json", "业务模块");
                c.SwaggerEndpoint("/swagger/dm/swagger.json", "其他模块");

                //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉，如果你想换一个路径，直接写名字即可，比如直接写c.RoutePrefix = "doc";
                c.RoutePrefix = "";
            });

            //app.UseHttpsRedirection();

            //静态文件中间件
            app.UseStaticFiles();

            //路由中间件
            app.UseRouting();

            //跨域
            app.UseCors();

            //可以通过静态变量向其他类中传递数据
            //RolePermission.Role = roleRepository.ListAsync().Result;

            //认证中间件
            app.UseAuthentication();

            //授权中间件
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
