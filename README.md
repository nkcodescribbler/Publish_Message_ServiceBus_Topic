To implement Azure Service Bus message sending using the Factory pattern with best practices.
  1) Encapsulate the creation of ServiceBusSender in a factory.
  2) Use dependency injection for configuration.
  3) Ensure proper resource management (IDisposable).
  4) Allow for easy testing and extension.

**Key Best Practices Used:**

  1) Factory encapsulates ServiceBusSender creation.
  2) ServiceBusClient is managed as a singleton for performance.
  3) Uses dependency injection and configuration.
  4) Proper disposal of resources.
  5) Easy to mock/fake in tests (via IServiceBusSenderFactory).
  6) Extensible for additional Service Bus features.
