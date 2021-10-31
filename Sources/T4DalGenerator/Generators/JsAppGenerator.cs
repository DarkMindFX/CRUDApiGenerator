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
    class JsAppGenerator : GeneratorBase
    {

        public JsAppGenerator(GeneratorParams genParams) : base(genParams)
        {
        }

        public override IList<string> Generate()
        {
            IList<string> result = new List<string>();

            var modelHelper = new ModelHelper();

            result.Add(GenerateAppJs(modelHelper));

            return result;
        }

        protected string GenerateAppJs(ModelHelper modelHelper)
        {
            string fileName = $"App.js";
            string fileOut = Path.Combine(GetOutputFolder(), fileName);

            var template = new JsAppTemplate();
            template.Session = new Dictionary<string, object>();
            template.Session["generator"] = this;
            template.Session["tables"] = _genParams.Tables;
            template.Session["modelHelper"] = modelHelper;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GetOutputFolder()
        {
            string outFolder = Path.Combine(_genParams.Settings.OutputRoot, _genParams.Timestamp.ToString("yyyy-MM-dd HH-mm-ss"), _genParams.Settings.OutputFolders["JSApp"]);
            if (!Directory.Exists(outFolder))
            {
                Directory.CreateDirectory(outFolder);
            }

            return outFolder;
        }
    }
}
