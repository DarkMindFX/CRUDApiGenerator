using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ModelExtractorParams
    {
        public string ConnectionString
        {
            get; set;
        }
    }

    public class ModelExtractor
    {
        private ModelExtractorParams _initParams;

        public void Init(ModelExtractorParams initParams)
        {
            this._initParams = initParams;
        }

        public IList<DataTable> GetModel()
        {
            IList<DataTable> result = new List<DataTable>();

            SqlConnection conn = new SqlConnection(_initParams.ConnectionString);
            conn.Open();

            using (conn)
            {
                IList<string> tableNames = GetDbTables(conn);
                foreach (var tName in tableNames)
                {
                    DataTable table = new DataTable();
                    table.Name = tName;
                    table.Columns = GetTableColumns(tName, conn);
                    result.Add(table);
                }
            }

            return result;
        }

        private IList<DataColumn> GetTableColumns(string tableName, SqlConnection conn)
        {
            IList<DataColumn> result = new List<DataColumn>();

            string query = $@"WITH CTE_PKs (table_name, column_name) AS 
                                (
                                SELECT  
                                        OBJECT_NAME(ic.OBJECT_ID) AS table_name,
                                        COL_NAME(ic.OBJECT_ID,ic.column_id) AS column_name
                                FROM    sys.indexes AS i INNER JOIN 
                                        sys.index_columns AS ic ON  i.OBJECT_ID = ic.OBJECT_ID
                                                                AND i.index_id = ic.index_id
                                WHERE   i.is_primary_key = 1
                                )
                                SELECT 
	                                schema_name(tab.schema_id) as [schema],
	                                tab.name as [table],
                                    col.column_id,
                                    col.name as column_name,
	                                sys_types.name as column_type,
	                                col.max_length, 
	                                col.precision,
	                                col.scale,
	                                col.is_nullable,
	                                col.is_identity,
	                                col.is_computed,
	                                CAST(IIF(CTE_PKs.column_name IS NOT NULL,1, 0) AS BIT) as is_primary_key,
	
                                    case when fk.object_id is not null then '>-' else null end as rel,
                                    pk_tab.name as primary_table,
                                    pk_col.name as pk_column_name,

                                    fk_cols.constraint_column_id as no,
                                    fk.name as fk_constraint_name
                                FROM sys.columns col
	                                inner join sys.types sys_types on sys_types.user_type_id = col.user_type_id 
                                    inner join sys.tables tab 
                                        on col.object_id = tab.object_id
	                                left join CTE_PKs ON CTE_PKs.column_name = col.name and CTE_PKs.table_name = tab.name
                                    left outer join sys.foreign_key_columns fk_cols
                                        on fk_cols.parent_object_id = tab.object_id
                                        and fk_cols.parent_column_id = col.column_id
                                    left outer join sys.foreign_keys fk
                                        on fk.object_id = fk_cols.constraint_object_id
                                    left outer join sys.tables pk_tab
                                        on pk_tab.object_id = fk_cols.referenced_object_id
                                    left outer join sys.columns pk_col
                                        on pk_col.column_id = fk_cols.referenced_column_id
                                        and pk_col.object_id = fk_cols.referenced_object_id
	
                                WHERE tab.name = '{tableName}' 
                                ORDER BY col.column_id";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = conn;

            DataSet ds = FillDataSet(cmd);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    DataType columnType = new DataType();
                    DataColumn column = new DataColumn();
                    column.Name = (string)r["column_name"];
                    columnType.SqlType = (string)r["column_type"];
                    columnType.CharMaxLength = RequireMaxLength(columnType.SqlType) ? ((Int16?)r["max_length"] > 0 ? (Int16?)r["max_length"] / 2 : 4000) : null;
                    columnType.Precision = RequirePrecision(columnType.SqlType) ? (int?)(byte)r["precision"] : null;
                    columnType.Scale = RequireScale(columnType.SqlType) ? (int?)(byte)r["scale"] : null;
                    column.Type = columnType;
                    column.IsIdentity = (bool)r["is_identity"];
                    column.IsComputed = (bool)r["is_computed"];
                    column.IsNullable = (bool)r["is_nullable"];
                    column.IsPK = (bool)r["is_primary_key"];
                    column.FKRefTable = !DBNull.Value.Equals(r["primary_table"]) ? (string)r["primary_table"] : null;
                    column.FKRefColumn = !DBNull.Value.Equals(r["pk_column_name"]) ? (string)r["pk_column_name"] : null;

                    result.Add(column);
                }
            }

            return result;
        }

        private bool RequireMaxLength(string typeName)
        {
            string[] types = new string[] { "char", "nchar", "varchar", "nvarchar", "binary", "varbinary" };

            foreach(var t in types)
            {
                if (t.ToLower().Equals(typeName.ToLower())) return true;
            }

            return false;
        }

        private bool RequirePrecision(string typeName)
        {
            string[] types = new string[] { "decimal" };

            foreach (var t in types)
            {
                if (t.ToLower().Equals(typeName.ToLower())) return true;
            }

            return false;
        }

        private bool RequireScale(string typeName)
        {
            string[] types = new string[] { "decimal" };

            foreach (var t in types)
            {
                if (t.ToLower().Equals(typeName.ToLower())) return true;
            }

            return false;
        }

        

        private IList<string> GetDbTables(SqlConnection conn)
        {
            IList<string> result = new List<string>();

            string query = "SELECT * FROM SYSOBJECTS WHERE xtype = 'U' ORDER BY name";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = conn;

            DataSet ds = FillDataSet(cmd);

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    result.Add((string)r["name"]);
                }
            }

            return result;

        }

        protected DataSet FillDataSet(SqlCommand cmd)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds);

            return ds;

        }
    }
}
