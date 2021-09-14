using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Rbac.Generator
{
    class Program
    {
        //基础路径
        private static string basePath = "../../../../";
        //项目名称
        private static string projectName = "Rbac.";

        static void Main(string[] args)
        {
            var ModuleName = "Contract";
            GeneratorCode(ModuleName, "Repository", true);
            GeneratorCode(ModuleName, "Repository", false);
            GeneratorCode(ModuleName, "Service", true);
            GeneratorCode(ModuleName, "Service", false);
            GeneratorCode(ModuleName, "WebAPI", isAPI: true);
            /*GeneratorDtos(ModuleName);
            GeneratorInject(ModuleName);
            GeneratorContext(ModuleName, "ContractId");
            GeneratorDbSet(ModuleName);*/
        }

        #region 生成仓储、Service的接口及实现层
        /// <summary>
        /// 生成仓储、Service的接口及实现层
        /// </summary>
        /// <param name="ModuleName"></param>
        /// <param name="LayerName"></param>
        /// <param name="isInterface"></param>
        static void GeneratorCode(string ModuleName, string LayerName, bool isInterface = false, bool isAPI = false)
        {
            //是否接口
            var Pre = isInterface ? "I" : "";
            //生成的目标文件名
            var targetFileName = $"{basePath}{projectName}{Pre}{LayerName}/";
            if (!isAPI)
            {
                targetFileName += $"{Pre}{ModuleName}{LayerName.TrimStart('I')}";
            }
            else
            {
                targetFileName += $"Controllers/{ModuleName}Controller";
            }
            //目标路径
            var targetPath = Path.GetFullPath($"{targetFileName}.cs");
            //模板路径
            var templatePath = Path.GetFullPath($"../../../{Pre}{LayerName}.template");
            //模板内容
            var templateContent = File.ReadAllText(templatePath);
            //生成的文件内容
            templateContent = templateContent.Replace("#ModuleName#", ModuleName);
            //写入文件
            File.WriteAllText(targetPath, templateContent);
        }
        #endregion

        #region 生成DTO
        /// <summary>
        /// 生成DTO
        /// </summary>
        /// <param name="ModuleName"></param>
        /// <param name="LayerName"></param>
        /// <param name="isInterface"></param>
        static void GeneratorDtos(string ModuleName, bool IsInsert = true, bool IsUpdate = false)
        {
            //目标路径
            var targetPath = Path.GetFullPath($"{basePath}{projectName}Dtos/{ModuleName}");
            //创建文件夹
            Directory.CreateDirectory(targetPath);
            //源文件路径
            var sourcePath = Path.GetFullPath($"{basePath}{projectName}Entity/{ModuleName}.cs");
            //读取源文件内容
            var entityContent = File.ReadAllText(sourcePath);

            Regex regex = new Regex(@"{([\S\s]+)}", RegexOptions.Multiline);

            var c = regex.Match(entityContent).Groups[1].Value;

            c = regex.Match(c).Groups[1].Value;

            //模板路径
            var templatePath = Path.GetFullPath($"../../../Dtos.template");
            //模板内容
            var templateContent = File.ReadAllText(templatePath);

            templateContent = templateContent.Replace("#PropertyList#", c);

            templateContent = templateContent.Replace("#ModuleName#", ModuleName);

            entityContent = templateContent.Replace("#DtoName#", "ListDto");

            File.WriteAllText($"{targetPath}/ListDto.cs", entityContent);
            if (IsInsert)
            {
                entityContent = templateContent.Replace("#DtoName#", "InsertDto");
                File.WriteAllText($"{targetPath}/InsertDto.cs", entityContent);
            }
            if (IsUpdate)
            {
                entityContent = templateContent.Replace("#DtoName#", "UpdateDto");
                File.WriteAllText($"{targetPath}/UpdateDto.cs", entityContent);
            }
        }
        #endregion

        #region 生成注入代码
        /// <summary>
        /// 生成注入代码
        /// </summary>
        /// <param name="ModuleName"></param>
        static void GeneratorInject(string ModuleName)
        {
            //目标路径
            var targetPath = Path.GetFullPath($"{basePath}{projectName}WebAPI/Inject/Injection.cs");

            var content = File.ReadAllText(targetPath);

            Regex regex = new Regex(@"public static void [\s\S\w\W]+?\}", RegexOptions.Multiline);

            var matchContent = regex.Match(content).Value;

            var inject = @$"    services.AddScoped<I{ModuleName}Repository, {ModuleName}Repository>();
            services.AddScoped<I{ModuleName}Service<Dtos.{ModuleName}.ListDto>, {ModuleName}Service<Dtos.{ModuleName}.ListDto>>();";

            var newContent = matchContent.Replace("}", $"{inject}{Environment.NewLine}        }}");

            newContent = regex.Replace(content, newContent);

            File.WriteAllText(targetPath, newContent);
        }
        #endregion

        #region 生成上下文
        /// <summary>
        /// 生成上下文
        /// </summary>
        /// <param name="ModuleName"></param>
        /// <param name="KeyName"></param>
        static void GeneratorContext(string ModuleName, string KeyName)
        {
            //目标路径
            var targetPath = Path.GetFullPath($"{basePath}{projectName}Entity/ModuleEntity.cs");

            var content = File.ReadAllText(targetPath);

            Regex regex = new Regex(@"{([\S\s]+)}", RegexOptions.Multiline);

            var c = regex.Match(content).Groups[1].Value;

            c = regex.Match(c).Groups[1].Value;

            c = regex.Match(c).Groups[1].Value;

            var newContent = c + @$"{Environment.NewLine}            modelBuilder.Entity<{ModuleName}>(action => {{
                action.HasKey(m => m.{KeyName});
            }});";

            //模板路径
            var templatePath = Path.GetFullPath($"../../../ModuleEntity.template");
            //模板内容
            var templateContent = File.ReadAllText(templatePath);

            templateContent = templateContent.Replace("#BuilderSetting#", newContent);

            File.WriteAllText(targetPath, templateContent);
        }
        #endregion

        /// <summary>
        /// 生成dbset
        /// </summary>
        /// <param name="ModuleName"></param>
        static void GeneratorDbSet(string ModuleName)
        {
            //目标路径
            var targetPath = Path.GetFullPath($"{basePath}{projectName}Entity/RbacDbContext.cs");

            var content = File.ReadAllText(targetPath);

            Regex regex = new Regex(@"public virtual [\s\S\w\W]+?}");

            var lastDbSet = regex.Matches(content).Last().Value;

            content = content.Replace(lastDbSet, $"{lastDbSet}{Environment.NewLine}        public virtual DbSet<{ModuleName}> {ModuleName} {{ get; set; }}");
            
            File.WriteAllText(targetPath, content);
        }
    }
}
