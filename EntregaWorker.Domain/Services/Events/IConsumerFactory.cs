using Confluent.Kafka;

namespace EntregaWorker.Domain.Service.Events
{
    public interface IConsumerFactory
    {
        IConsumer<string, string> GetConsumer();
    }
}
