using CRUDAPI.DataModel;
using CRUDAPI.Template.NET.API;
using System;
using System.Collections.Generic;
using System.IO;


namespace CRUDAPI.Generators
{
    public class EntitiesGenerator : GeneratorBase
    {
        public EntitiesGenerator(GeneratorParams genParams) : base(genParams)
        {
        }

        public override IList<string> Generate()
        {
            IList<string> files = new List<string>();

            var modelHelper = new ModelHelper();

            files.Add(GenerateEntity(modelHelper));

            return files;
        }

        protected string GenerateEntity(ModelHelper modelHelper)
        {
            string fileName = $"{_genParams.Table.Name}.cs";
            string fileOut = Path.Combine(GetOutputFolder(), fileName);

            var template = new EntityTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GetOutputFolder()
        {
            string outFolder = Path.Combine(_genParams.Settings.OutputRoot, _genParams.Timestamp.ToString("yyyy-MM-dd HH-mm-ss"), _genParams.Settings.OutputFolders["Entities"]);
            outFolder = base.CreateDirectory(outFolder);

            return outFolder;
        }
    }
}
