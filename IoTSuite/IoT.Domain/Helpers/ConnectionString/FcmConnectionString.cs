using System;
namespace IoT.Domain.Helpers.ConnectionString
{
    public sealed class FirebaseCloudMessageConnectionString
    {
        public string SenderId { get; private set; }
        public string ApplicationId { get; private set; }
        public string Uri { get; private set; }
        internal void Parsing(string senderId, string applicationId, string uri = @"https://fcm.googleapis.com/fcm/send")
        {
            this.SenderId = senderId;
            this.ApplicationId = applicationId;
            this.Uri = uri;
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