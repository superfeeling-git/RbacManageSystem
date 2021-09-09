using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rbac.Entity;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Rbac.WebAPI.Inject;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore.Filters;
using System.IO;

namespace Rbac.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string ApiName { get; set; } = "Rbac.Core";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
            //添加JSON序列化编码，防止中文被编码为Unicode字符。
            .AddNewtonsoftJson(options =>
            {
                //修改属性名称的序列化方式，首字母小写
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

                //修改时间的序列化方式
                options.SerializerSettings.Converters.Add(new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd HH:mm:ss" });
            }).AddControllersAsServices();

            services.AddCors(option => {
                option.AddDefaultPolicy(build => {
                    build.AllowCredentials();
                    build.AllowAnyMethod();
                    build.AllowAnyHeader();
                    build.WithOrigins("http://localhost:8080").AllowCredentials();
                });
            });

            services.AddDbContext<RbacDbContext>(option => {
                option.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
            });

            //便于其他类库访问HTTP上下文
            services.AddHttpContextAccessor();

            services.inject();

            services.AddAuthentication(option => {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(
                option => {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        //是否验证发行人
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["JwtConfig:Bearer:Issuer"],//发行人

                        //是否验证受众人
                        ValidateAudience = true,
                        ValidAudience = Configuration["JwtConfig:Bearer:Audience"],//受众人

                        //是否验证密钥
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtConfig:Bearer:SecurityKey"])),

                        ValidateLifetime = true, //验证生命周期

                        RequireExpirationTime = true, //过期时间

                        ClockSkew = TimeSpan.Zero   //平滑过期偏移时间
                    };
                }
            );

            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new OpenApiInfo
                {
                    // {ApiName} 定义成全局变量，方便修改
                    Version = "V1",
                    Title = $"{ApiName} 接口文档——Netcore 5.0",
                    Description = $"{ApiName} HTTP API V1",
                });
                options.OrderActionsBy(o => o.RelativePath);

                //就是这里！！！！！！！！！
                var xmlPath = Path.Combine(basePath, "Rbac.WebAPI.xml");//这个就是刚刚配置的xml文件名
                options.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改

                //就是这里！！！！！！！！！
                var xmlPath_Entity = Path.Combine(basePath, "Rbac.Entity.xml");//这个就是刚刚配置的xml文件名
                options.IncludeXmlComments(xmlPath_Entity, true);//默认的第二个参数是false，这个是controller的注释，记得修改

                //就是这里！！！！！！！！！
                var xmlPath_Dtos = Path.Combine(basePath, "Rbac.Dtos.xml");//这个就是刚刚配置的xml文件名
                options.IncludeXmlComments(xmlPath_Dtos, true);//默认的第二个参数是false，这个是controller的注释，记得修改

                //开启权限小锁
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                //在header中添加token，传递到后台
                options.OperationFilter<SecurityRequirementsOperationFilter>();
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传递)直接在下面框中输入Bearer {token}(注意两者之间是一个空格) \"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"/swagger/V1/swagger.json", $"{ApiName} V1");

                    //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉，如果你想换一个路径，直接写名字即可，比如直接写c.RoutePrefix = "doc";
                    c.RoutePrefix = "";
                });
            }

            //app.UseHttpsRedirection();

            //路由中间件
            app.UseRouting();

            //跨域
            app.UseCors();

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
