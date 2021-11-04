using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDAPI.DataModel;
using CRUDAPI.Template.NET.Tests;

namespace CRUDAPI.Generators
{
    public class ControllerTestGenerator : GeneratorBase
    {

        public ControllerTestGenerator(GeneratorParams genParams) : base(genParams)
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
            foreach(var pk in pks)
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
            string fileName = $"Test{modelHelper.Pluralize(_genParams.Table.Name)}Controller.cs";
            string fileOut = Path.Combine(GetOutputFolder(), fileName);

            var template = new TestControllerTemplate();
            template.Session = new Dictionary<string, object>();
            
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
            string outFolder = Path.Combine(_genParams.Settings.OutputRoot, _genParams.Timestamp.ToString("yyyy-MM-dd HH-mm-ss"), 
                                            _genParams.Settings.OutputFolders["ControllerTests"]);
            if (!Directory.Exists(outFolder))
            {
                Directory.CreateDirectory(outFolder);
            }

            return outFolder;
        }

        #region Support methods
        private IDictionary<string, object> GenerateTestValues(DataModel.DataTable table, string uuid)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();

            for (int i = 0; i < table.Columns.Count; ++i)
            {
                var c = table.Columns[i];
                if (!c.IsIdentity)
                {
                    result[c.Name] = GetRandomValue(c, uuid);
                }
            }

            return result;
        }

        private object GetRandomValue(DataModel.DataColumn c, string uuid)
        {
            var modelHelper = new ModelHelper();
            object result = null;
            Type columnType = modelHelper.GetColumnType(c);

            if (!string.IsNullOrEmpty(c.FKRefTable) && !string.IsNullOrEmpty(c.FKRefColumn))
            {
                object randColValue = GetRandomTableColumnValue(c.FKRefTable, c.FKRefColumn);
                if (randColValue != null)
                {
                    result = (columnType == typeof(string)) ? $"\"{randColValue.ToString()}\"" : randColValue.ToString();
                }
            }
            else
            {
                var rnd = new Random(DateTime.Now.Millisecond);
                if (columnType == typeof(string))
                {
                    string value = $"{c.Name} {uuid}";
                    if (value.Length > c.Type.CharMaxLength)
                    {
                        value = value.Substring(0, (int)c.Type.CharMaxLength);
                    }
                    result = value;
                }
                else if (columnType == typeof(int) || columnType == typeof(long))
                {
                    result = rnd.Next(1, 1000 * (columnType == typeof(long) ? 1000 : 1));
                }
                else if (columnType == typeof(decimal))
                {
                    result = Math.Round(rnd.NextDouble() * 1000000, (int)c.Type.Scale);
                }
                else if (columnType == typeof(float))
                {
                    result = rnd.NextDouble() * 1000000;
                }
                else if (columnType == typeof(bool))
                {
                    result = rnd.Next(1, 100) % 2 != 0;
                }
                else if (columnType == typeof(DateTime))
                {
                    result = DateTime.Now.AddDays(rnd.Next(-1000, 1000)).AddMinutes(rnd.Next(-1000, 1000));
                }
            }

            return result;
        }

        private object GetRandomTableColumnValue(string table, string column)
        {
            string sql = $"SELECT TOP 1 [{column}] FROM [dbo].[{table}] ORDER BY NEWID()";
            object result = null;

            using (var conn = new SqlConnection(_genParams.Settings.ConnectionString))
            {
                conn.Open();

                var cmd = new SqlCommand(sql);
                cmd.Connection = conn;

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    result = ds.Tables[0].Rows[0][0];
                }
            }

            return result;
        }
        #endregion
    }
}
