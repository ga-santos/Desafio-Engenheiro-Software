using Consumer.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Consumer.Infrastructure.Configurations
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;
        public MongoDBContext(IOptions<MongoConfig> opcoes)
        {
            MongoClient mongoClient = new MongoClient(opcoes.Value.Server);

            if (mongoClient != null)
                _database = mongoClient.GetDatabase(opcoes.Value.Database);
        }

        public IMongoCollection<Pedido> Pedidos
        {
            get
            {
                return _database.GetCollection<Pedido>("pedidos");
            }
        }
    }
}
