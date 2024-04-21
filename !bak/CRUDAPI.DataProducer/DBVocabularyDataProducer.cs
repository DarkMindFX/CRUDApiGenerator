using CRUDAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.DataProducer
{
    public class DBVocabularyDataProducerParams : IDataProducerParams
    {
        public string ConnectionString { get; set; }

        public uint MaxLength { get; set; }

        public long VocabularyID { get; set; }
    }

    public class DBVocabularyDataProducer : IDataProducer<string>
    {
        private DBVocabularyDataProducerParams _initParams;

        public void Init(IDataProducerParams initParams)
        {
            _initParams = initParams as DBVocabularyDataProducerParams;

            if (string.IsNullOrEmpty(_initParams.ConnectionString))
                throw new ArgumentException("ConnectionString is empty. Provide connection string to DB which contains vocabulary");

            if (_initParams.VocabularyID <= 0)
                throw new ArgumentException("VocabularyID must be greater than 0");

            if (_initParams.MaxLength == 0)
                throw new ArgumentException("MaxLength must be greater than 0");
        }

        public string NextValue()
        {
            string result = GetNextRandomValue();

            return result;
        }

        #region Support methods
        private SqlConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection(this._initParams.ConnectionString);

            conn.Open();

            return conn;
        }

        private string GetNextRandomValue()
        {
            string value = null;
            using (SqlConnection conn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.p_Vocabulary_GetRandomValue";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.Add(new SqlParameter("@VocabularyID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, _initParams.VocabularyID));
                cmd.Parameters.Add(new SqlParameter("@MaxLength", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, _initParams.MaxLength));
                var outValue = cmd.Parameters.Add(new SqlParameter("@Result", SqlDbType.NVarChar, 1000, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Default, null));

                cmd.ExecuteNonQuery();

                value = (string)outValue.Value;
            }
            return value;
        }

        #endregion
    }
}
