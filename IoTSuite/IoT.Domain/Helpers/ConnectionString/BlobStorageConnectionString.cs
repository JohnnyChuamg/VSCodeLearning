using System;
using System.Collections;
using System.Collections.Generic;
using IoT.Domain.Extensions;

namespace IoT.Domain.Helpers.ConnectionString
{
    public sealed class BlobStorageConnectionString
    {
        public string ConnectionString { get; private set; }
        public string DefaultEndPointsProtocol { get; private set; }
        public string AccountName { get; private set; }
        public string AccountKey { get; private set; }
        public string EndPointSuffix { get; private set; }
        public BlobStorageConnectionString() { }
        internal void Parsing(string connectionString)
        {
            IDictionary<string, string> dictionary = connectionString.AzureConnectionStringToDictionary(';', '=');
            this.ConnectionString = connectionString;
            this.DefaultEndPointsProtocol = dictionary.GetValueOrDefault(nameof(DefaultEndPointsProtocol));
            this.AccountName = dictionary.GetValueOrDefault(nameof(AccountName));
            this.AccountKey = dictionary.GetValueOrDefault(nameof(AccountKey));
            this.EndPointSuffix = dictionary.GetValueOrDefault(nameof(EndPointSuffix));
        }
        public static BlobStorageConnectionString Create(string connectionstring)
        {
            if (string.IsNullOrWhiteSpace(connectionstring))
                throw new ArgumentNullException("BlobStorage Connection string can't be empty or whitespace");
            BlobStorageConnectionString result = new BlobStorageConnectionString();
            result.Parsing(connectionstring);
            return result;
        }
    }
}