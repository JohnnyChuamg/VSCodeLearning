using System;
using Newtonsoft.Json;
using IoT.Domain.Helpers.ConnectionString;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;

namespace IoT.DataLayer.Managers
{
    public class FirebaseCloudMessageManager
    {
        public FirebaseCloudMessageConnectionString ConnectionString { get; private set; }
        public FirebaseCloudMessageManager(FirebaseCloudMessageConnectionString conn) { ConnectionString = conn; }
        public static FirebaseCloudMessageManager Create(string senderId, string applicationId)
        {
            if (string.IsNullOrWhiteSpace(senderId)) throw new ArgumentNullException("Firebase cloud message senderId can't be empty or null");
            if (string.IsNullOrWhiteSpace(applicationId)) throw new ArgumentNullException("Firebase cloid message applicationId can't be empty or null");
            return new FirebaseCloudMessageManager(FirebaseCloudMessageConnectionString.Create(senderId, applicationId));
        }
        public async Task CloudMessaging(string to, string title, string content)
        {

        }
        internal async Task<string> CloudMessaging(string jsonData)
        {
            string result = string.Empty;
            WebRequest tRequest = WebRequest.Create(this.ConnectionString.Uri);
            tRequest.Method = "POST";
            tRequest.ContentType = "application/json";
            byte[] byteAry = Encoding.UTF8.GetBytes(jsonData);
            tRequest.Headers.Add($"Authorization: key={this.ConnectionString.ApplicationId}");
            tRequest.Headers.Add(string.Format($"Sender: id={this.ConnectionString.SenderId}"));
            tRequest.ContentLength = byteAry.Length;
            using (Stream dataStream = await tRequest.GetRequestStreamAsync())
            {
                await dataStream.WriteAsync(byteAry, 0, byteAry.Length);
                using (WebResponse tResponse = await tRequest.GetResponseAsync())
                using (Stream dataStreamResponse = tResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(dataStreamResponse))
                {
                    result = await sr.ReadToEndAsync();
                }
            }
            return result;
        }
    }
}