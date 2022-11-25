using CRUDAPI.DataModel;
using CRUDAPI.Template.NET.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Generators
{
    public class EntityControllerGenerator : GeneratorBase
    {

        public EntityControllerGenerator(GeneratorParams genParams) : base(genParams)
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
            string fileName = $"{modelHelper.Pluralize(_genParams.Table.Name)}Controller.cs";
            string fileOut = Path.Combine(GetOutputFolder(), fileName);

            var template = new EntityControllerTemplate();
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
            string outFolder = Path.Combine(_genParams.Settings.OutputRoot, 
                                            _genParams.Timestamp.ToString("yyyy-MM-dd HH-mm-ss"), 
                                            _genParams.Settings.OutputFolders["Controllers"], 
                                            _genParams.Settings.APIVersion);
            outFolder = base.CreateDirectory(outFolder);

            return outFolder;
        }
    }
}
