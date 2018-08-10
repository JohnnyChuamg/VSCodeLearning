using System;
using IoT.Domain.Helpers.ConnectionString;

namespace IoT.DataLayer.Managers
{
    public class BlobStorageManager
    {
        public string ContainerName { get; private set; }
        public BlobStorageConnectionString ConnectionString { get; private set; }

        public BlobStorageManager(BlobStorageConnectionString conn, string containerName)
        {
            ConnectionString = conn;
            ContainerName = containerName;
        }
        public static BlobStorageManager CreateByConnectionString(string connectionString, string containerName)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("Blob storage connection string can't be empty or null");
            if (string.IsNullOrWhiteSpace(containerName))
                throw new ArgumentNullException("ContainerName can't be empty or null");
            return new BlobStorageManager(BlobStorageConnectionString.Create(connectionString), containerName);
        }

    }
}