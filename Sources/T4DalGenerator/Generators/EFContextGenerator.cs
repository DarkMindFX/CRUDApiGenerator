using CRUDAPI.DataModel;
using CRUDAPI.Generators;
using CRUDAPI.Template.NET.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Generator
{
    internal class EFContextGenerator : GeneratorBase
    {

        public EFContextGenerator(GeneratorParams genParams) : base(genParams)
        {
        }

        public override IList<string> Generate()
        {
            IList<string> result = new List<string>();

            var modelHelper = new ModelHelper();

            result.Add(GenerateEFContext(modelHelper));

            return result;
        }

        protected string GenerateEFContext(ModelHelper modelHelper)
        {
            string fileName = $"{_genParams.Settings.ProjectName}Context.cs";
            string fileOut = Path.Combine(GetOutputFolder(), fileName);

            var template = new EFContextTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["tables"] = _genParams.Tables;
            template.Session["modelHelper"] = modelHelper;
            template.Session["projectName"] = _genParams.Settings.ProjectName;
            template.Session["connectionString"] = _genParams.Settings.ConnectionString;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GetOutputFolder()
        {
            string outFolder = Path.Combine(_genParams.Settings.OutputRoot, _genParams.Timestamp.ToString("yyyy-MM-dd HH-mm-ss"), _genParams.Settings.OutputFolders["EFModels"]);
            outFolder = base.CreateDirectory(outFolder);

            return outFolder;
        }

    }
}
