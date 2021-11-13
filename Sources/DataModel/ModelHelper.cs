using CRUDAPI.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.DataModel
{
    public class ModelHelper
    {
        public string Pluralize(string name)
        {
            string result = string.Empty;
            if(name.EndsWith("y"))
            {
                var endIdx = name.LastIndexOf('y');
                result = name.Substring(0, endIdx) + "ies";
            }
            else if (name.EndsWith("s"))
            {
                result = name + "es";
            }
            else
            {
                result = name + "s";
            }

            return result;
        }

        public string WithoutID(string name)
        {
            string result = name;
            if(name.ToUpper().EndsWith("ID"))
            {
                result = name.Remove(name.ToUpper().LastIndexOf("ID"), 2);
            }
            return result;
        }
        
        public string DbTypeToType(DataModel.DataColumn c)
        {
            string result = null;
            Type type = GetColumnType(c);

            result = type.ToString();

            if (c.IsIdentity || (c.IsNullable && !type.IsClass && Nullable.GetUnderlyingType(type) == null))
            {
                result += "?";
            }

            return result;
        }        

        public Type GetColumnType(string name)
        {
            Type type = null;

            switch (name.ToLower())
            {
                case "int":
                    type = typeof(Int32);
                    break;
                case "date":
                case "datetime":
                case "datetime2":
                    type = typeof(DateTime);
                    break;
                case "bit":
                    type = typeof(bool);
                    break;
                case "bigint":
                    type = typeof(long);
                    break;
                case "float":
                    type = typeof(float);
                    break;
                case "money":
                case "decimal":
                    type = typeof(decimal);
                    break;
                case "char":
                case "nchar":
                case "varchar":
                case "nvarchar":
                case "text":
                case "ntext":
                case "xml":
                    type = typeof(string);
                    break;
            }

            return type;
        }

        public Type GetColumnType(DataModel.DataColumn c)
        {
            Type type = GetColumnType(c.Type.SqlType);
            
            return type;
        }

        public string DbTypeToSqlDbType(DataColumn c)
        {
            string type = null;

            IDictionary<string, System.Data.SqlDbType> mapping = new Dictionary<string, System.Data.SqlDbType>();
            mapping.Add("int", System.Data.SqlDbType.Int);
            mapping.Add("date", System.Data.SqlDbType.Date);
            mapping.Add("datetime", System.Data.SqlDbType.DateTime);
            mapping.Add("datetime2", System.Data.SqlDbType.DateTime2);
            mapping.Add("timestamp", System.Data.SqlDbType.Timestamp);
            mapping.Add("time", System.Data.SqlDbType.Time);
            mapping.Add("bit", System.Data.SqlDbType.Bit);
            mapping.Add("bigint", System.Data.SqlDbType.BigInt);
            mapping.Add("float", System.Data.SqlDbType.Float);
            mapping.Add("money", System.Data.SqlDbType.Money);
            mapping.Add("decimal", System.Data.SqlDbType.Decimal);
            mapping.Add("char", System.Data.SqlDbType.Char);
            mapping.Add("nchar", System.Data.SqlDbType.NChar);
            mapping.Add("varchar", System.Data.SqlDbType.VarChar);
            mapping.Add("nvarchar", System.Data.SqlDbType.NVarChar);
            mapping.Add("text", System.Data.SqlDbType.Text);
            mapping.Add("ntext", System.Data.SqlDbType.NText);
            mapping.Add("xml", System.Data.SqlDbType.Xml);

            type = mapping[c.Type.SqlType].ToString();

            return type;
        }

        public string GenerateParamDeclaration(DataColumn c)
        {
            StringBuilder result = new StringBuilder();

            result.Append($"@{c.Name} {c.Type.SqlType.ToUpper()}");
            if (c.Type.CharMaxLength != null) result.Append($"({c.Type.CharMaxLength})");
            if (c.Type.Precision != null && c.Type.Scale != null) result.Append($"({c.Type.Precision}, {c.Type.Scale})");

            return result.ToString();
        }

        public string GenerateVariableDeclaration(DataColumn c, string prefix = "")
        {
            StringBuilder result = new StringBuilder();

            result.Append($"DECLARE @{prefix}{c.Name} {c.Type.SqlType.ToUpper()}");
            if (c.Type.CharMaxLength != null) result.Append($"({c.Type.CharMaxLength})");
            if (c.Type.Precision != null && c.Type.Scale != null) result.Append($"({c.Type.Precision}, {c.Type.Scale})");

            return result.ToString();
        }

        public string NewUUID()
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty).Replace("{", string.Empty).Replace("}", string.Empty);
        }

        public IList<DataColumn> GetPKColumns(DataTable table)
        {
            return table.Columns.Where(c => c.IsPK).ToList();
        }

        public IList<DataModel.DataColumn> GetFKColumns(DataModel.DataTable table)
        {
            List<DataModel.DataColumn> fks = new List<DataModel.DataColumn>();
            fks.AddRange(table.Columns.Where(c => !string.IsNullOrEmpty(c.FKRefColumn)));

            return fks;
        }
    }
}
