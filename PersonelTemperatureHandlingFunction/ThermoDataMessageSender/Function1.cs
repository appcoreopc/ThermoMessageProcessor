using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.ServiceBus;

namespace ThermoDataMessageSender
{
    public static class Function1
    {
        [FunctionName("MessageSender")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
           const string ServiceBusConnectionString = "Endpoint=sb://devsbbank.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ZeoCedTJSaqVPAx8bHX998DVIYHtuG5g0OKlUkUFF9g=";
            const string QueueName = "devsbqbank";
            IQueueClient queueClient;

            log.LogInformation($"Target queue name : {QueueName}");

            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);
            var qms = new QueueMessageSender(queueClient);

            for (int i = 0; i < 10; i++)
            {

                var d = new
                {
                    Name = "jeremy" + DateTime.Now,
                    Email = "kepung@gmail.com"
                };

                await qms.SendMessagesAsync(MessageConverter.Serialize(d));
                log.LogInformation($"Sending:i {d.Name}");

            }



            return new OkObjectResult($"Sent {DateTime.Now}.");
        }
    }
}

    public class MessageConverter
    {

        public static string Serialize<T>(T sourceObject)
        {
            return JsonConvert.SerializeObject(sourceObject);
        }
    }