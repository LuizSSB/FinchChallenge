using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Configuration;

namespace FinchBackend
{
    public static class DatabaseProvider
    {
        static readonly string Address = ConfigurationManager.AppSettings["DatabaseAddress"];
        static readonly string Database = ConfigurationManager.AppSettings["DatabaseName"];

        static string ConnectionString => String.Format(
            "Server={0};Database={1};Trusted_Connection=True;",
            Address, Database
        );

        public static IDbConnectionFactory PrepareDatabase()
        {
            var dbConnection = new OrmLiteConnectionFactory(ConnectionString, SqlServerDialect.Provider);
            using (var db = dbConnection.Open())
            {
                db.CreateTableIfNotExists<ServiceModel.Types.Debtor>();
                db.CreateTableIfNotExists<ServiceModel.Types.Payment>();
                db.CreateTableIfNotExists<ServiceModel.Types.PaymentProtest>();
            }
            return dbConnection;
        }
    }
}