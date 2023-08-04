using CRUDAPI.DataProducer;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.CRUDAPI.DataProducer
{
    public class TestSettings
    {
        [JsonProperty(PropertyName = "ConnectionString")]
        public string ConnectionString
        {
            get;
            set;
        }
    }

    public class TestDBVocabularyDataProducer
    {

        IConfiguration _config = null;
        [SetUp]
        public void Setup()
        {
            _config = GetConfiguration();
        }

        [TestCase((uint)3, "FirstName")]
        [TestCase((uint)5, "FirstName")]
        [TestCase((uint)10, "FirstName")]
        [TestCase((uint)100, "FirstName")]
        public void GetNextVocabularValue_GivenMaxLength_Success(uint maxLength, string vocabularyName)
        {
            // Setup
            DBVocabularyDataProducerParams initParams = new DBVocabularyDataProducerParams();
            initParams.MaxLength = maxLength;
            initParams.ConnectionString = _config.GetSection("TestSettings").Get<TestSettings>().ConnectionString;
            initParams.VocabularyID = (long)GetVocabularyIDByName(vocabularyName);
            var producer = new DBVocabularyDataProducer();
            producer.Init(initParams);

            // Execute 
            var nextValue = producer.NextValue();

            // Check
            Assert.IsNotNull(nextValue);
            Assert.True(nextValue.Length > 0);
            Assert.True(nextValue.Length <= maxLength);
        }

        #region Support methods
        protected IConfiguration GetConfiguration()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return config;
        }

        protected long? GetVocabularyIDByName(string name)
        {
            long? result = null;

            using(var conn = new SqlConnection(_config.GetSection("TestSettings").Get<TestSettings>().ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.p_Vocabulary_GetIDByName";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.Add(new SqlParameter("@VocabularyName", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, name));
                var outID = cmd.Parameters.Add(new SqlParameter("@VocabularyID", SqlDbType.BigInt, 0, ParameterDirection.Output, false, 0, 0, null, DataRowVersion.Default, null));

                cmd.ExecuteNonQuery();

                if(outID.Value != DBNull.Value)
                {
                    result = (long)outID.Value;
                }
            }

            return result;
        }
        #endregion  
    }
}
