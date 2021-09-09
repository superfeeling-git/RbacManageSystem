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
            //���JSON���л����룬��ֹ���ı�����ΪUnicode�ַ���
            .AddNewtonsoftJson(options =>
            {
                //�޸��������Ƶ����л���ʽ������ĸСд
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

                //�޸�ʱ������л���ʽ
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

            //��������������HTTP������
            services.AddHttpContextAccessor();

            services.inject();

            services.AddAuthentication(option => {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(
                option => {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        //�Ƿ���֤������
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["JwtConfig:Bearer:Issuer"],//������

                        //�Ƿ���֤������
                        ValidateAudience = true,
                        ValidAudience = Configuration["JwtConfig:Bearer:Audience"],//������

                        //�Ƿ���֤��Կ
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtConfig:Bearer:SecurityKey"])),

                        ValidateLifetime = true, //��֤��������

                        RequireExpirationTime = true, //����ʱ��

                        ClockSkew = TimeSpan.Zero   //ƽ������ƫ��ʱ��
                    };
                }
            );

            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new OpenApiInfo
                {
                    // {ApiName} �����ȫ�ֱ����������޸�
                    Version = "V1",
                    Title = $"{ApiName} �ӿ��ĵ�����Netcore 5.0",
                    Description = $"{ApiName} HTTP API V1",
                });
                options.OrderActionsBy(o => o.RelativePath);

                //�����������������������
                var xmlPath = Path.Combine(basePath, "Rbac.WebAPI.xml");//������Ǹո����õ�xml�ļ���
                options.IncludeXmlComments(xmlPath, true);//Ĭ�ϵĵڶ���������false�������controller��ע�ͣ��ǵ��޸�

                //�����������������������
                var xmlPath_Entity = Path.Combine(basePath, "Rbac.Entity.xml");//������Ǹո����õ�xml�ļ���
                options.IncludeXmlComments(xmlPath_Entity, true);//Ĭ�ϵĵڶ���������false�������controller��ע�ͣ��ǵ��޸�

                //�����������������������
                var xmlPath_Dtos = Path.Combine(basePath, "Rbac.Dtos.xml");//������Ǹո����õ�xml�ļ���
                options.IncludeXmlComments(xmlPath_Dtos, true);//Ĭ�ϵĵڶ���������false�������controller��ע�ͣ��ǵ��޸�

                //����Ȩ��С��
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                //��header�����token�����ݵ���̨
                options.OperationFilter<SecurityRequirementsOperationFilter>();
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���)ֱ���������������Bearer {token}(ע������֮����һ���ո�) \"",
                    Name = "Authorization",//jwtĬ�ϵĲ�������
                    In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
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

                    //·�����ã�����Ϊ�գ���ʾֱ���ڸ�������localhost:8001�����ʸ��ļ�,ע��localhost:8001/swagger�Ƿ��ʲ����ģ�ȥlaunchSettings.json��launchUrlȥ����������뻻һ��·����ֱ��д���ּ��ɣ�����ֱ��дc.RoutePrefix = "doc";
                    c.RoutePrefix = "";
                });
            }

            //app.UseHttpsRedirection();

            //·���м��
            app.UseRouting();

            //����
            app.UseCors();

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
