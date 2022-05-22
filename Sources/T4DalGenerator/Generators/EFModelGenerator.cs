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
    public class EFModelGenerator : GeneratorBase
    {
        public EFModelGenerator(GeneratorParams genParams) : base(genParams)
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

            var template = new EFModelTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Session["refTables"] = GetRefTables(_genParams.Table.Name, _genParams.Tables);
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GetOutputFolder()
        {
            string outFolder = Path.Combine(_genParams.Settings.OutputRoot, _genParams.Timestamp.ToString("yyyy-MM-dd HH-mm-ss"), _genParams.Settings.OutputFolders["EFModels"]);
            if (!Directory.Exists(outFolder))
            {
                Directory.CreateDirectory(outFolder);
            }

            return outFolder;
        }

        private IList<DataModel.DataTable> GetRefTables(string pkTable, IList<DataModel.DataTable> tables)
        {
            var result = new List<DataModel.DataTable>();

            foreach(var t in tables)
            {
                if(t.Columns.Where( c => c.FKRefTable != null && c.FKRefTable.Equals(pkTable) ).Any())
                {
                    result.Add(t);
                }
            }
            return result;
        }
    }
}
