using Azure.Messaging.ServiceBus;

namespace Backend.Common
{
    public class ServiceBusMessageSender
    {
        private readonly ServicebusProvider servicebusProvider;
        public ServiceBusMessageSender(ServicebusProvider provider)
        {
            this.servicebusProvider = provider;
        }

        public async Task SendMessageAsync(string topicName, string body)
        {
            ServiceBusSender sender = this.servicebusProvider.CreateSender(topicName);
            if (sender != null)
            {
                await sender.SendMessageAsync(new ServiceBusMessage(body));
            }
        }
    }
}
