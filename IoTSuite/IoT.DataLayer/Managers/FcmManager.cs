using System;
using Newtonsoft.Json;
using IoT.Domain.Extensions.ConnectionString;
namespace IoT.DataLayer.Managers
{
    public class FirebaseCloudMessageManager
    {
        public FirebaseCloudMessageConnectionString ConnectionString { get; private set; }
        public FirebaseCloudMessageManager(FirebaseCloudMessageConnectionString conn) { ConnectionString = conn; }
        public static FirebaseCloudMessageManager Create(string senderId, string applicationId)
            => new FirebaseCloudMessageManager(FirebaseCloudMessageConnectionString.Create(senderId, applicationId));
    }
}