using Backend.Common;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Http;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;
namespace Backend.Controllers
{
    public class SendMessageFunction
    {
        public readonly ServiceBusMessageSender sender;


        public SendMessageFunction(ServiceBusMessageSender sender)
        {
            this.sender = sender;
        }

        public string QueueName { get; } = Environment.GetEnvironmentVariable("ServiceBusQueueName") ?? string.Empty;

        public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req, FunctionContext context)
        {
            var body = await req.ReadAsStringAsync();
            await this.sender.SendMessageAsync(QueueName, body);

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteStringAsync("Message sent to Service Bus queue.");
            return response;
        }
    }
}
