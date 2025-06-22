using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;

namespace Service_Azure_Bus.AzureServiceBus
{
    public class ServiceBusSenderFactory : IServiceBusSenderFactory, IDisposable
    {
        private readonly ServiceBusClient _client;
        private bool _disposed;

        public ServiceBusSenderFactory(IOptions<ServiceBusOptions> options)
        {
            _client = new ServiceBusClient(options.Value.ConnectionString);
        }

        public ServiceBusSender CreateSender(string topicName)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(ServiceBusSenderFactory));
            return _client.CreateSender(topicName);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _client.DisposeAsync().GetAwaiter().GetResult();
                _disposed = true;
            }
        }
    }
}
