using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4DalGenerator.Templates;
using T4DalGenerator.Templates.UI;

namespace T4DalGenerator.Generators
{
    public class JsClientDalGenerator : GeneratorBase
    {

        public JsClientDalGenerator(GeneratorParams genParams) : base(genParams)
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
            string fileName = $"{modelHelper.Pluralize(_genParams.Table.Name)}Dal.js";
            string fileOut = Path.Combine(GetOutputFolder(), fileName);

            var template = new JsClientDalTemplate();
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
            string outFolder = Path.Combine(_genParams.Settings.OutputRoot, _genParams.Timestamp.ToString("yyyy-MM-dd HH-mm-ss"), _genParams.Settings.OutputFolders["JSClientDals"]);
            if (!Directory.Exists(outFolder))
            {
                Directory.CreateDirectory(outFolder);
            }

            return outFolder;
        }
    }
}
