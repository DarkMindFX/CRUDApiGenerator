using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4DalGenerator
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
        public string DbTypeToSqlDbType(DataModel.DataColumn c)
        {
            string type = null;

            IDictionary<string, SqlDbType> mapping = new Dictionary<string, SqlDbType>();
            mapping.Add("int", SqlDbType.Int);
            mapping.Add("date", SqlDbType.Date);
            mapping.Add("datetime", SqlDbType.DateTime2);
            mapping.Add("bit", SqlDbType.Bit);
            mapping.Add("bigint", SqlDbType.BigInt);
            mapping.Add("float", SqlDbType.Float);
            mapping.Add("money", SqlDbType.Money);
            mapping.Add("decimal", SqlDbType.Decimal);
            mapping.Add("char", SqlDbType.Char);
            mapping.Add("nchar", SqlDbType.NChar);
            mapping.Add("varchar", SqlDbType.VarChar);
            mapping.Add("nvarchar", SqlDbType.NVarChar);
            mapping.Add("text", SqlDbType.Text);
            mapping.Add("ntext", SqlDbType.NText);
            mapping.Add("xml", SqlDbType.Xml);

            type = mapping[c.Type.SqlType].ToString();

            return type;
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

        public string NewUUID()
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty).Replace("{", string.Empty).Replace("}", string.Empty);
        }
    }
}
