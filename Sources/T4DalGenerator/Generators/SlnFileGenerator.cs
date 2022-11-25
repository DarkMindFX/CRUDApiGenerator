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
    class SlnFileGenerator : GeneratorBase
    {

        public SlnFileGenerator(GeneratorParams genParams) : base(genParams)
        {
        }

        public override IList<string> Generate()
        {
            IList<string> result = new List<string>();

            var modelHelper = new ModelHelper();

            result.Add(GenerateSetup(modelHelper));

            return result;
        }

        protected string GenerateSetup(ModelHelper modelHelper)
        {
            string fileName = $"{base._genParams.Settings.RootNamespace}.API.sln";
            string fileOut = Path.Combine(GetOutputFolder(), fileName);

            var template = new SolutionTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["FunctionProjectNameTemplate"] = _genParams.Settings.FunctionProjectNameTemplate;
            template.Session["tables"] = _genParams.Tables;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            // deleting other sln files - if exist
            var slnFiles = Directory.GetFiles(GetOutputFolder(), "*.sln");
            foreach(var slnFile in slnFiles)
            {
                File.Delete(slnFile);
            }

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GetOutputFolder()
        {
            string outFolder = Path.Combine(_genParams.Settings.OutputRoot, _genParams.Timestamp.ToString("yyyy-MM-dd HH-mm-ss"), _genParams.Settings.OutputFolders["SlnFileDest"]);
            outFolder = base.CreateDirectory(outFolder);

            return outFolder;
        }
    }
}
