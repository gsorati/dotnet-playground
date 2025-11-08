using Azure.Messaging.ServiceBus;
namespace Backend.Common
{
    public class ServicebusProvider
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;
        private ServiceBusClient serviceBusClient;

        public ServicebusProvider(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("Servicebus") ?? string.Empty;
            serviceBusClient = new ServiceBusClient(connectionString);
        }

        public ServiceBusSender CreateSender(string topicName)
        {
            return this.serviceBusClient.CreateSender(topicName);
        }
    }
}
