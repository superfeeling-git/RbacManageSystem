using System;
using System.IO;

namespace Rbac.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var ModuleName = "GoodsCategory";
            /*GeneratorCode(ModuleName, "Repository", true);
            GeneratorCode(ModuleName, "Repository", false);
            GeneratorCode(ModuleName, "Service", true);
            GeneratorCode(ModuleName, "Service", false);*/
            GeneratorCode(ModuleName, "WebAPI", isAPI: true);
            GeneratorDtos(ModuleName);

            //生成Dtos
            //生成控制器
        }

        /// <summary>
        /// 生成仓储、Service的接口及实现层
        /// </summary>
        /// <param name="ModuleName"></param>
        /// <param name="LayerName"></param>
        /// <param name="isInterface"></param>
        static void GeneratorDtos(string ModuleName,bool IsInsert = true, bool IsUpdate = false)
        {
            //基础路径
            var basePath = "../../../../";
            //项目名称
            var projectName = "Rbac.";
            //目标路径
            var targetPath = Path.GetFullPath($"{basePath}{projectName}Dtos/{ModuleName}");
            //创建文件夹
            Directory.CreateDirectory(targetPath);
            //源文件路径
            var sourcePath = Path.GetFullPath($"{basePath}{projectName}Entity/{ModuleName}.cs");
            //读取源文件内容
            var entityContent = File.ReadAllText(sourcePath);
            File.WriteAllText($"{targetPath}/ListDto.cs", entityContent);
            if (IsInsert)
                File.WriteAllText($"{targetPath}/InsertDto.cs", entityContent);
            if (IsUpdate)
                File.WriteAllText($"{targetPath}/UpdateDto.cs", entityContent);
        }


        /// <summary>
        /// 生成仓储、Service的接口及实现层
        /// </summary>
        /// <param name="ModuleName"></param>
        /// <param name="LayerName"></param>
        /// <param name="isInterface"></param>
        static void GeneratorCode(string ModuleName,string LayerName,bool isInterface = false,bool isAPI = false)
        {
            //基础路径
            var basePath = "../../../../";
            //项目名称
            var projectName = "Rbac.";
            //是否接口
            var Pre = isInterface ? "I" : "";
            //生成的目标文件名
            var targetFileName = $"{basePath}{projectName}{Pre}{LayerName}/{Pre}{ModuleName}{LayerName.TrimStart('I')}";
            if (isAPI)
                targetFileName += "Controller";
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
    }
}
