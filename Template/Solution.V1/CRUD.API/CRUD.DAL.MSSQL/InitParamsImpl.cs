using PPT.Interfaces;
using System.Collections.Generic;


namespace PPT.DAL.MSSQL
{
    public class InitParamsImpl : IInitParams
    {
        public InitParamsImpl()
        {
            Parameters = new Dictionary<string, string>();
            Parameters["ConnectionString"] = string.Empty;
        }

        public Dictionary<string, string> Parameters
        {
            get;
            set;
        }
    }
}
