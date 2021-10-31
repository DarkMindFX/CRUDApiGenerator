using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace PPT.Common
{
    public abstract class SQLDal
    {
        protected string connectionString;
        protected object ValueOrDBNull(object value)
        {
            return value != null ? value : DBNull.Value;
        }

        protected SqlConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection(this.connectionString);
            conn.Open();

            return conn;
        }       

        protected void CloseConnection(SqlConnection conn)
        {
            conn.Close();
        }

        protected void InitDbConnection(string connString)
        {
            connectionString = connString;
        }

        protected SqlParameter AddParameter(SqlCommand cmd, string parameterName, SqlDbType dbType, int size, ParameterDirection direction, bool isNullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
        {
            SqlParameter p = new SqlParameter(parameterName, dbType, size, direction, isNullable, precision, scale, sourceColumn, sourceVersion, value);
            cmd.Parameters.Add(p);

            return p;
        }

        protected DataSet FillDataSet(SqlCommand cmd)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds);

            return ds;
        }

        protected TEntity Get<TEntity>(string procName, long id, string paramName, Func<DataRow, TEntity> fnFromRow) where TEntity : new()
        {
            TEntity result = default(TEntity);

            result = GetBy<TEntity, long>(procName, id, paramName, SqlDbType.BigInt, 0, fnFromRow).FirstOrDefault();

            return result;
        }

        protected IList<TEntity> GetBy<TEntity, TParamType>(string procName, TParamType byParam, string paramName, SqlDbType sqlType, int sqlSize, Func<DataRow, TEntity> fnFromRow)
        {
            IList<TEntity> result = new List<TEntity>();

            using (SqlConnection conn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand(procName, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                AddParameter(cmd, paramName, sqlType, sqlSize, ParameterDirection.Input, false, 0, 0, string.Empty, DataRowVersion.Current, byParam);

                var pFound = AddParameter(cmd, "@Found", SqlDbType.Bit, 0, ParameterDirection.Output, false, 0, 0, string.Empty, DataRowVersion.Current, 0);

                var ds = FillDataSet(cmd);

                if (ds.Tables.Count >= 1)
                {
                    result = new List<TEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var c = fnFromRow(row);

                        result.Add(c);
                    }
                }
            }

            return result;
        }

        protected TEntity Upsert<TEntity>(string procName, TEntity entity, Func<SqlCommand, TEntity, SqlCommand> fnAddParams , Func<DataRow, TEntity> fnFromRow)
        {
            TEntity result = default(TEntity);

            using (SqlConnection conn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand(procName, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd = fnAddParams(cmd, entity);

                var ds = FillDataSet(cmd);

                if (ds.Tables.Count >= 1 && ds.Tables[0].Rows.Count > 0)
                {
                    result = fnFromRow(ds.Tables[0].Rows[0]);
                }
            }

            return result;
        }

        protected bool Delete<TEntity>(string procName, long id, string paramName) where TEntity : new()
        {
            bool result = false;

            using (SqlConnection conn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand(procName, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                AddParameter(cmd, paramName, SqlDbType.BigInt, 0, ParameterDirection.Input, false, 0, 0, string.Empty, DataRowVersion.Current, id);

                var pFound = AddParameter(cmd, "@Removed", SqlDbType.Bit, 0, ParameterDirection.Output, false, 0, 0, string.Empty, DataRowVersion.Current, 0);

                cmd.ExecuteNonQuery();

                result = (bool)pFound.Value;
            }

            return result;
        }

        protected IList<TEntity> GetAll<TEntity>(string procName, Func<DataRow, TEntity> fnFromRow)
        {
            IList<TEntity> result = null;

            using (SqlConnection conn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand(procName, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var ds = FillDataSet(cmd);

                if (ds.Tables.Count >= 1)
                {
                    result = new List<TEntity>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var c = fnFromRow(row);

                        result.Add(c);
                    }
                }
            }

            return result;

        }
    }
}
