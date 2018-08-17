using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IoT.WebJob.DataRecevier.Process
{
    public class IoTMessageProcess
    {
        public void Proddcessor(IEnumerable<EventData> messages)
        {
            foreach (var message in messages)
            {
                string deviceId = string.Empty;
                try
                {
                    var data = JsonConvert.DeserializeObject<JObject>(Encoding.UTF8.GetString(message.GetBytes()));

                }
                catch (System.Exception)
                {

                    throw;
                }
            }
        }
    }

}