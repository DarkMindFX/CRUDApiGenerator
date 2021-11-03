using CRUDAPI.DataModel;
using CRUDAPI.Template.NET.Tests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace CRUDAPI.Generators
{
    public class SQLDalTestGenerator : GeneratorBase
    {

        public SQLDalTestGenerator(GeneratorParams genParams) : base(genParams)
        {
        }

        public override IList<string> Generate()
        {
            IList<string> files = new List<string>();

            var modelHelper = new ModelHelper();

            string getUUID = NewUUID();
            string deleteUUID = NewUUID();
            string eraseUUID = NewUUID();
            string insertUUID = NewUUID();
            string updateBeforeUUID = NewUUID();
            string updateAfterUUID = NewUUID();

            IDictionary<string, object> testValsGet = GenerateTestValues(_genParams.Table, getUUID);
            IDictionary<string, object> testValsDelete = GenerateTestValues(_genParams.Table, deleteUUID);
            IDictionary<string, object> testValsErase = GenerateTestValues(_genParams.Table, eraseUUID);
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
            files.Add(GenerateGetSetup(modelHelper, testValsGet));
            files.Add(GenerateGetTeardown(modelHelper, testValsGet));
            files.Add(GenerateInsertSetup(modelHelper, testValsInsert));
            files.Add(GenerateInsertTeardown(modelHelper, testValsInsert));
            files.Add(GenerateDeleteSetup(modelHelper, testValsDelete));
            files.Add(GenerateDeleteTeardown(modelHelper, testValsDelete));
            files.Add(GenerateUpdateSetup(modelHelper, testValsUpdateBefore));
            files.Add(GenerateUpdateTeardown(modelHelper, testValsUpdateBefore, testValsUpdateAfter));
            if (_genParams.Settings.IsSoftDelete && _genParams.Table.HasColumn(_genParams.Settings.SoftDeleteField))
            {
                files.Add(GenerateEraseSetup(modelHelper, testValsErase));
                files.Add(GenerateEraseTeardown(modelHelper, testValsErase));
            }

            return files;
        }



        protected string GenerateTestClass(ModelHelper modelHelper, 
                                            IDictionary<string, object> testValsGet,
                                            IDictionary<string, object> testValsInsert,
                                            IDictionary<string, object> testValsUpdateAfter)
        {
            string fileName = $"Test{_genParams.Table.Name}Dal.cs";
            string fileOut = Path.Combine(GetOutputFolder(), fileName);

            var template = new TestDalTemplate();
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

        protected string GenerateGetSetup(ModelHelper modelHelper,
                                            IDictionary<string, object> testValsGet)
        {
            string fileName = $"Setup.sql";
            string fileOut = Path.Combine(GetOutputFolder(), "000.GetDetails.Success", fileName);
            string dirOut = Path.GetDirectoryName(fileOut);

            if (!Directory.Exists(dirOut))
            {
                Directory.CreateDirectory(dirOut);
            }

            var template = new GetDetailsSetupTemplate();
            template.Session = new Dictionary<string, object>();
            
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Session["testValsGet"] = testValsGet;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GenerateGetTeardown(ModelHelper modelHelper,
                                            IDictionary<string, object> testValsGet)
        {
            string fileName = $"Teardown.sql";
            string fileOut = Path.Combine(GetOutputFolder(), "000.GetDetails.Success", fileName);
            string dirOut = Path.GetDirectoryName(fileOut);

            if (!Directory.Exists(dirOut))
            {
                Directory.CreateDirectory(dirOut);
            }

            var template = new GetDetailsTeardownTemplate();
            template.Session = new Dictionary<string, object>();
            
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Session["testValsGet"] = testValsGet;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GenerateInsertSetup(ModelHelper modelHelper,
                                            IDictionary<string, object> testValsInsert)
        {
            string fileName = $"Setup.sql";
            string fileOut = Path.Combine(GetOutputFolder(), "020.Insert.Success", fileName);
            string dirOut = Path.GetDirectoryName(fileOut);

            if (!Directory.Exists(dirOut))
            {
                Directory.CreateDirectory(dirOut);
            }

            var template = new InsertSetupTemplate();
            template.Session = new Dictionary<string, object>();
            
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Session["testValsInsert"] = testValsInsert;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GenerateInsertTeardown(ModelHelper modelHelper,
                                            IDictionary<string, object> testValsInsert)
        {
            string fileName = $"Teardown.sql";
            string fileOut = Path.Combine(GetOutputFolder(), "020.Insert.Success", fileName);
            string dirOut = Path.GetDirectoryName(fileOut);

            if (!Directory.Exists(dirOut))
            {
                Directory.CreateDirectory(dirOut);
            }

            var template = new InsertTeardownTemplate();
            template.Session = new Dictionary<string, object>();
            
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Session["testValsInsert"] = testValsInsert;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GenerateDeleteSetup(ModelHelper modelHelper,
                                            IDictionary<string, object> testValsDelete)
        {
            string fileName = $"Setup.sql";
            string fileOut = Path.Combine(GetOutputFolder(), "010.Delete.Success", fileName);
            string dirOut = Path.GetDirectoryName(fileOut);

            if (!Directory.Exists(dirOut))
            {
                Directory.CreateDirectory(dirOut);
            }

            var template = new DeleteSetupTemplate();
            template.Session = new Dictionary<string, object>();
            
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Session["testValsDelete"] = testValsDelete;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GenerateDeleteTeardown(ModelHelper modelHelper,
                                            IDictionary<string, object> testValsDelete)
        {
            string fileName = $"Teardown.sql";
            string fileOut = Path.Combine(GetOutputFolder(), "010.Delete.Success", fileName);
            string dirOut = Path.GetDirectoryName(fileOut);

            if (!Directory.Exists(dirOut))
            {
                Directory.CreateDirectory(dirOut);
            }

            var template = new DeleteTeardownTemplate();
            template.Session = new Dictionary<string, object>();
            
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Session["testValsDelete"] = testValsDelete;
            template.Session["IsSoftDelete"] = _genParams.Settings.IsSoftDelete;
            template.Session["SoftDeleteField"] = _genParams.Settings.SoftDeleteField;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GenerateUpdateSetup(ModelHelper modelHelper,
                                            IDictionary<string, object> testValsUpdateBefore)
        {
            string fileName = $"Setup.sql";
            string fileOut = Path.Combine(GetOutputFolder(), "030.Update.Success", fileName);
            string dirOut = Path.GetDirectoryName(fileOut);

            if (!Directory.Exists(dirOut))
            {
                Directory.CreateDirectory(dirOut);
            }

            var template = new UpdateSetupTemplate();
            template.Session = new Dictionary<string, object>();
            
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Session["testValsUpdateBefore"] = testValsUpdateBefore;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GenerateUpdateTeardown(ModelHelper modelHelper,
                                            IDictionary<string, object> testValsUpdateBefore,
                                            IDictionary<string, object> testValsUpdateAfter)
        {
            string fileName = $"Teardown.sql";
            string fileOut = Path.Combine(GetOutputFolder(), "030.Update.Success", fileName);
            string dirOut = Path.GetDirectoryName(fileOut);

            if (!Directory.Exists(dirOut))
            {
                Directory.CreateDirectory(dirOut);
            }

            var template = new UpdateTeardownTemplate();
            template.Session = new Dictionary<string, object>();
            
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Session["testValsUpdateBefore"] = testValsUpdateBefore;
            template.Session["testValsUpdateAfter"] = testValsUpdateAfter;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GenerateEraseSetup(ModelHelper modelHelper,
                                            IDictionary<string, object> testValsErase)
        {
            string fileName = $"Setup.sql";
            string fileOut = Path.Combine(GetOutputFolder(), "040.Erase.Success", fileName);
            string dirOut = Path.GetDirectoryName(fileOut);

            if (!Directory.Exists(dirOut))
            {
                Directory.CreateDirectory(dirOut);
            }

            var template = new EraseSetupTemplate();
            template.Session = new Dictionary<string, object>();
            
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Session["testValsErase"] = testValsErase;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GenerateEraseTeardown(ModelHelper modelHelper,
                                            IDictionary<string, object> testValsErase)
        {
            string fileName = $"Teardown.sql";
            string fileOut = Path.Combine(GetOutputFolder(), "040.Erase.Success", fileName);
            string dirOut = Path.GetDirectoryName(fileOut);

            if (!Directory.Exists(dirOut))
            {
                Directory.CreateDirectory(dirOut);
            }

            var template = new EraseTeardownTemplate();
            template.Session = new Dictionary<string, object>();
            
            template.Session["table"] = _genParams.Table;
            template.Session["modelHelper"] = modelHelper;
            template.Session["testValsErase"] = testValsErase;
            template.Initialize();

            string content = template.TransformText();

            File.WriteAllText(fileOut, content);

            return fileOut;
        }

        protected string GetOutputFolder()
        {
            string outFolder = Path.Combine(_genParams.Settings.OutputRoot, _genParams.Timestamp.ToString("yyyy-MM-dd HH-mm-ss"), 
                                            _genParams.Settings.OutputFolders["DalSQLTests"], _genParams.Table.Name);
            if (!Directory.Exists(outFolder))
            {
                Directory.CreateDirectory(outFolder);
            }

            return outFolder;
        }

        #region Support methods
        private IDictionary<string, object> GenerateTestValues(CRUDAPI.DataModel.DataTable table, string uuid)
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

        private object GetRandomValue(CRUDAPI.DataModel.DataColumn c, string uuid)
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
                else if(columnType == typeof(decimal))
                {
                    result = Math.Round(rnd.NextDouble() * 1000000 , (int)c.Type.Scale);
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
