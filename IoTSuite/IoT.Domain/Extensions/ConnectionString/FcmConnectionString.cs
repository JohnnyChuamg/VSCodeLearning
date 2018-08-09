using System;
namespace IoT.Domain.Extensions.ConnectionString
{
    public sealed class FirebaseCloudMessageConnectionString
    {
        public string SenderId { get; private set; }
        public string ApplicationId { get; private set; }
        internal void Parsing(string senderId, string applicationId)
        {
            this.SenderId = senderId;
            this.ApplicationId = applicationId;
        }
        public static FirebaseCloudMessageConnectionString Create(string senderId, string applicationId)
        {
            if (string.IsNullOrWhiteSpace(senderId)) throw new ArgumentNullException("FCM SenderId can't be empty or null");
            if (string.IsNullOrWhiteSpace(applicationId)) throw new ArgumentNullException("FCM ApplicationId can't be empty or null");
            var result = new FirebaseCloudMessageConnectionString();
            result.Parsing(senderId, applicationId);
            return result;
        }

    }
}