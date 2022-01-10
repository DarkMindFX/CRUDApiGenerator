namespace PPT.Functions.Common
{
    public class Constants
    {
        public static readonly string ENV_DAL_TYPE = "ServiceConfig__DALType";

        public static readonly string ENV_SQL_CONNECTION_STRING = "ServiceConfig__DalInitParams__ConnectionString";

        public static readonly string ENV_STORAGE_CONNECTION_STRING = "ServiceConfig__StorageInitParams__StorageConnectionString";

        public static readonly string ENV_JWT_SECRET = "ServiceConfig__AppSettings__Secret";

        public static readonly string ENV_SESSION_TIMEOUT = "ServiceConfig__AppSettings__SessionTimeout";

    }
}