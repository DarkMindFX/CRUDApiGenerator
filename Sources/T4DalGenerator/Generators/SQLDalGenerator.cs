using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4DalGenerator.Templates;
using T4DalGenerator.Templates.API;

namespace T4DalGenerator.Generators
{
    public class ConvertorsGenerator : GeneratorBase
    {
 
        public ConvertorsGenerator(GeneratorParams genParams) : base(genParams)
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
            string fileName = $"{_genParams.Table.Name}Convertor.cs";
            string fileOut = Path.Combine(GetOutputFolder(), fileName);

            var template = new EntityConvertorTemplate();
            template.Session = new Dictionary<string, object>();
            template.Session["generator"] = this;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GetOutputFolder()
        {
            string outFolder = Path.Combine(_genParams.Settings.OutputRoot, _genParams.Timestamp.ToString("yyyy-MM-dd HH-mm-ss"), _genParams.Settings.OutputFolders["Convertors"]);
            if (!Directory.Exists(outFolder))
            {
                Directory.CreateDirectory(outFolder);
            }

            return outFolder;
        }
    }
}
