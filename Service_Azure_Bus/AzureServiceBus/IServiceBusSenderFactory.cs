using Azure.Messaging.ServiceBus;

namespace Service_Azure_Bus.AzureServiceBus
{
    public interface IServiceBusSenderFactory
    {
        ServiceBusSender CreateSender(string topicName);
    }
}
