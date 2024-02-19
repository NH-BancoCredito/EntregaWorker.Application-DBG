using Confluent.Kafka;
using EntregaWorker.Domain.Service.Events;

namespace EntregaWorker.Infrastructure.Services.Events
{
    public class ConsumerFactory : IConsumerFactory
    {
        private static Lazy<IConsumer<string, string>> LazyKafkaConnection = null;

        public ConsumerFactory(ConsumerConfig config)
        {
            LazyKafkaConnection = new Lazy<IConsumer<string, string>>(() => new ConsumerBuilder<string, string>(config).Build());
        }
        public IConsumer<string, string> GetConsumer()
            => LazyKafkaConnection.Value;
    }
}
