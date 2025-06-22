using Azure.Messaging.ServiceBus;

namespace Service_Azure_Bus.AzureServiceBus
{
    public class MessagePublisher
    {
        private readonly IServiceBusSenderFactory _senderFactory;

        public MessagePublisher(IServiceBusSenderFactory senderFactory)
        {
            _senderFactory = senderFactory;
        }

        public async Task PublishAsync(string topic, string message)
        {
            await using var sender = _senderFactory.CreateSender(topic);
            var serviceBusMessage = new ServiceBusMessage(message);
            await sender.SendMessageAsync(serviceBusMessage);
        }
    }
}
