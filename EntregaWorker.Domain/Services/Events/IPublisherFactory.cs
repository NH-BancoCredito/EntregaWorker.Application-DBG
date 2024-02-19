using Confluent.Kafka;

namespace EntregaWorker.Domain.Service.Events
{
    public interface IPublisherFactory
    {
        IProducer<string, string> GetProducer();
    }
}
