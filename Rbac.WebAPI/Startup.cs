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

            //����
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

            //EF Core��db������
            services.AddDbContext<RbacDbContext>(option => {
                option.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
            });

            //��������������HTTP������
            services.AddHttpContextAccessor();

            services.AddHttpContext();

            //ʹ��.net core�Դ���ע��
            services.AddIoc();

            //JWT��֤����
            services.AddJwtBearer();

            //Swagger����
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
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "ͨ��ģ��");
                c.SwaggerEndpoint("/swagger/gp/swagger.json", "��¼ģ��");
                c.SwaggerEndpoint("/swagger/mom/swagger.json", "ҵ��ģ��");
                c.SwaggerEndpoint("/swagger/dm/swagger.json", "����ģ��");

                //·�����ã�����Ϊ�գ���ʾֱ���ڸ�������localhost:8001�����ʸ��ļ�,ע��localhost:8001/swagger�Ƿ��ʲ����ģ�ȥlaunchSettings.json��launchUrlȥ����������뻻һ��·����ֱ��д���ּ��ɣ�����ֱ��дc.RoutePrefix = "doc";
                c.RoutePrefix = "";
            });

            //app.UseHttpsRedirection();

            //��̬�ļ��м��
            app.UseStaticFiles();

            //·���м��
            app.UseRouting();

            //����
            app.UseCors();

            //����ͨ����̬�������������д�������
            //RolePermission.Role = roleRepository.ListAsync().Result;

            //��֤�м��
            app.UseAuthentication();

            //��Ȩ�м��
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
