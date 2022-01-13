using CRUDAPI.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Generators
{
    public abstract class TestGeneratorBase : GeneratorBase
    {
        public TestGeneratorBase(GeneratorParams genParams) : base(genParams)
        {

        }

        #region Support methods
        protected IDictionary<string, object> GenerateTestValues(DataModel.DataTable table, string uuid)
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

        protected object GetRandomValue(DataModel.DataColumn c, string uuid)
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

        protected object GetRandomTableColumnValue(string table, string column)
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
