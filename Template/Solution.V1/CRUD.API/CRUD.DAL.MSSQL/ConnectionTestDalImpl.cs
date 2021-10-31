using PPT.Common;
using PPT.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

namespace PPT.DAL.MSSQL
{
    class ConnectionTestDalInitParams : InitParamsImpl
    {
    }

    [Export("MSSQL", typeof(IConnectionTestDal))]
    public class ConnectionTestDalImpl : SQLDal, IConnectionTestDal
    {
        public IInitParams CreateInitParams()
        {
            return new ConnectionTestDalInitParams();
        }

        public void Init(IInitParams initParams)
        {
            InitDbConnection(initParams.Parameters["ConnectionString"]);
        }

        public ConnectionTestResult TestConnection()
        {
            var result = new ConnectionTestResult();
            result.Errors = new List<Exception>();

            try
            {
                var conn = this.OpenConnection();
                if(conn.State != System.Data.ConnectionState.Open)
                {
                    result.Success = false;
                    result.Errors.Add(new Exception($"Failed to connect to {this.connectionString}"));
                }
                else
                {
                    this.CloseConnection(conn);
                    result.Success = true;
                }
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Errors.Add(ex);
            }

            return result;
        }
    }
}
