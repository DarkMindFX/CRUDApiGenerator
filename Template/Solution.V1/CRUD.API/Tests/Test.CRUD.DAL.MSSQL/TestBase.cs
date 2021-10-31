using PPT.DAL.MSSQL;
using PPT.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Test.PPT.DAL.MSSQL
{
    public class TestBase
    {
        public class TestDalInitParams
        {
            [JsonProperty(PropertyName = "ConnectionString")]
            public string ConnectionString
            {
                get;
                set;
            }
        }

        protected IList<object> SetupCase(SqlConnection conn, string caseRoot)
        {
            IList<object> result = null;
            string fileName = "Setup.sql";
            string path = Path.Combine(TestBaseFolder, caseRoot, fileName);
            if (File.Exists(path))
            {
                result = RunScript(conn, path);
            }

            return result;
        }

        protected SqlConnection OpenConnection(string settingsName)
        {
            IConfiguration config = GetConfiguration();
            var initParams = config.GetSection(settingsName).Get<TestDalInitParams>();
            SqlConnection conn = new SqlConnection(initParams.ConnectionString);
            conn.Open();

            return conn;
        }

        protected void CloseConnection(SqlConnection conn)
        {
            if(conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        protected IList<object> TeardownCase(SqlConnection conn, string caseRoot)
        {
            IList<object> result = null;
            string fileName = "Teardown.sql";
            string path = Path.Combine(TestBaseFolder, caseRoot, fileName);
            if (File.Exists(path))
            {
                result = RunScript(conn, path);
            }

            return result;
        }

        protected IList<object> RunScript(SqlConnection conn, string filePath)
        {
            IList<object> result = null;
            string sql = File.ReadAllText(filePath);
            if (!string.IsNullOrEmpty(sql))
            {
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                using (var reader = cmd.ExecuteReader())
                {
                    result = new List<object>();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        for (int i = 0; i < reader.FieldCount; ++i)
                        {
                            result.Add(reader[i]);
                        }
                    }
                }
            }

            return result;
        }

        protected string TestBaseFolder
        {
            get
            {
                return Path.Combine(TestContext.CurrentContext.TestDirectory, "..\\..\\..");
            }
        }

        protected IConfiguration GetConfiguration()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appconfig.json", optional: false, reloadOnChange: true)
                .Build();

            return config;
        }

        
    }
}
