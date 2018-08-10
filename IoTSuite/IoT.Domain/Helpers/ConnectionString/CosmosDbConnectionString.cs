using System;
using IoT.Domain.Extensions;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Azure.Documents.Client;

namespace IoT.Domain.Helpers.ConnectionString
{
    public sealed class CosmosDBConnectionString
    {
        public string ConnectionString { get; private set; }
        public string Uri { get; private set; }
        public string Key { get; private set; }
        public string DbId { get; private set; }
        public string CollectionId { get; private set; }
        public Uri EndPointUri => new Uri(this.Uri);
        public Uri DataBaseUri => UriFactory.CreateDatabaseUri(DbId);
        public Uri CollectionUri => UriFactory.CreateDocumentCollectionUri(DbId, CollectionId);
        public Uri DocumentUri(string Id) => UriFactory.CreateDocumentUri(DbId, CollectionId, Id);
        public CosmosDBConnectionString() { }
        internal void Parsing(string connectionString, string dbId, string collectionId)
        {
            IDictionary<string, string> dict = connectionString.AzureConnectionStringToDictionary(':', '=');
            ConnectionString = connectionString;
            Uri = dict.GetValueOrDefault(nameof(Uri));
            Key = dict.GetValueOrDefault(nameof(Key));
            DbId = dict.GetValueOrDefault(nameof(DbId));
            CollectionId = dict.GetValueOrDefault(nameof(CollectionId));
        }
        public static CosmosDBConnectionString Create(string connectionString, string dbId, string collectionId)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException("Cosmos Db connectionstring can't be empty or null。");
            if (string.IsNullOrWhiteSpace(dbId)) throw new ArgumentNullException("Cosmos db dbId can't be empty or null");
            if (string.IsNullOrWhiteSpace(collectionId)) throw new ArgumentNullException("Cosmos db collectionId can't be empty or null");
            CosmosDBConnectionString result = new CosmosDBConnectionString();
            result.Parsing(connectionString, dbId, collectionId);
            return result;
        }
    }
}