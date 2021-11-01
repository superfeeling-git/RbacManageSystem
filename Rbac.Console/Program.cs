using System;
using System.Collections.Generic;
using Rbac.Entity;
using Newtonsoft.Json;

namespace Rbac.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin {
                AdminId = 1,
                UserName = "superadmin",
                Password = Guid.NewGuid().ToString(),
                CreateTime = DateTime.Now,
                LastLoginTime = DateTime.Now.AddDays(30)
            };

            string str = "{\"AdminId\":1,\"UserName\":\"superadmin\",\"Password\":\"529d158a-08e7-4084-bd86-bf8b5faf22e9\",\"LastLoginTime\":\"2021-11-18T09:33:22.7976433+08:00\",\"AdminRole\":null,\"CreateById\":0,\"CreateByName\":null,\"CreateTime\":\"2021-10-19T09:33:22.797546+08:00\"}";

            var adminobj = JsonConvert.DeserializeObject<Admin>(str);

            Console.WriteLine(adminobj.UserName);

            Console.ReadLine();
        }
    }
}
