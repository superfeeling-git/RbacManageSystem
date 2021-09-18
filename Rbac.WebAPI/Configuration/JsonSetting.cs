using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rbac.WebAPI.Configuration
{
    /// <summary>
    /// //添加JSON序列化编码，防止中文被编码为Unicode字符。
    /// </summary>
    public static class JsonSetting
    {
        public static IMvcBuilder AddJsonSetting(this IMvcBuilder mvc)
        {
            return mvc.AddNewtonsoftJson(options =>
            {
                //修改属性名称的序列化方式，首字母小写
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

                //修改时间的序列化方式
                options.SerializerSettings.Converters.Add(new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd HH:mm:ss" });
            }).AddControllersAsServices();
        }
    }
}
