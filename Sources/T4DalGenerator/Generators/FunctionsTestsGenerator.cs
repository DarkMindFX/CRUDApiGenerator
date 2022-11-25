using CRUDAPI.DataModel;
using CRUDAPI.Generators;
using CRUDAPI.Template.NET.Tests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Generators
{
    public class FunctionsTestsGenerator  : TestGeneratorBase
    {

        public FunctionsTestsGenerator(GeneratorParams genParams) : base(genParams)
        {
        }

        public override IList<string> Generate()
        {
            IList<string> files = new List<string>();

            var modelHelper = new ModelHelper();

            string getUUID = NewUUID();
            string deleteUUID = NewUUID();
            string insertUUID = NewUUID();
            string updateBeforeUUID = NewUUID();
            string updateAfterUUID = NewUUID();

            IDictionary<string, object> testValsGet = GenerateTestValues(_genParams.Table, getUUID);
            IDictionary<string, object> testValsDelete = GenerateTestValues(_genParams.Table, deleteUUID);
            IDictionary<string, object> testValsInsert = GenerateTestValues(_genParams.Table, insertUUID);
            IDictionary<string, object> testValsUpdateBefore = GenerateTestValues(_genParams.Table, updateBeforeUUID);
            IDictionary<string, object> testValsUpdateAfter = GenerateTestValues(_genParams.Table, updateAfterUUID);

            // PKs should stay the same
            var pks = modelHelper.GetPKColumns(_genParams.Table);
            foreach (var pk in pks)
            {
                if (testValsUpdateBefore.ContainsKey(pk.Name))
                {
                    testValsUpdateAfter[pk.Name] = testValsUpdateBefore[pk.Name];
                }
            }

            files.Add(GenerateTestClass(modelHelper, testValsGet, testValsInsert, testValsUpdateAfter));

            return files;
        }



        protected string GenerateTestClass(ModelHelper modelHelper,
                                            IDictionary<string, object> testValsGet,
                                            IDictionary<string, object> testValsInsert,
                                            IDictionary<string, object> testValsUpdateAfter)
        {
            string fileName = $"TestFunctions{_genParams.Table.Name}.cs";
            string fileOut = Path.Combine(GetOutputFolder(), fileName);

            var template = new TestFunctionsTemplate();
            template.Session = new Dictionary<string, object>();

            template.Session["RootNamespace"] = _genParams.Settings.RootNamespace;
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Session["testValsGet"] = testValsGet;
            template.Session["testValsInsert"] = testValsInsert;
            template.Session["testValsUpdateAfter"] = testValsUpdateAfter;
            template.Session["IsSoftDelete"] = _genParams.Settings.IsSoftDelete;
            template.Session["SoftDeleteField"] = _genParams.Settings.SoftDeleteField;

            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }



        protected string GetOutputFolder()
        {
            string outFolder = Path.Combine(_genParams.Settings.OutputRoot,
                                            _genParams.Timestamp.ToString("yyyy-MM-dd HH-mm-ss"),
                                            _genParams.Settings.OutputFolders["FunctionTests"],
                                            _genParams.Settings.APIVersion);
            outFolder = base.CreateDirectory(outFolder);

            return outFolder;
        }
    }
}
