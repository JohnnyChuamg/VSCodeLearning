using IoT.Domain.Helpers.ConnectionString;
using System;
namespace IoT.DataLayer.Managers
{
    public class CosmosManager
    {
        public CosmosDBConnectionString ConnectionString { get; private set; }
        public CosmosManager(CosmosDBConnectionString conn)
        {
            ConnectionString = conn;
        }
        public static CosmosManager CreateByConnectionString(string connectionString, string dbId, string collectionId)
        {
            return new CosmosManager(CosmosDBConnectionString.Create(connectionString, dbId, collectionId));
        }
    }
}