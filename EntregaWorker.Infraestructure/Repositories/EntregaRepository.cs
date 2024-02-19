using EntregaWorker.Domain.Models;
using EntregaWorker.Domain.Repositories;
using MongoDB.Driver;
using static Confluent.Kafka.ConfigPropertyNames;

namespace EntregaWorker.Infraestructure.Repositories
{
    public class EntregaRepository : IEntregaRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public EntregaRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }
        public async Task<bool> Registrar(Entrega entity)
        {
            await getMongoCollection().InsertOneAsync(entity);
            return true;
        }

        private IMongoCollection<Entrega> getMongoCollection() => _mongoDatabase.GetCollection<Entrega>(nameof(Entrega));
    }
}
