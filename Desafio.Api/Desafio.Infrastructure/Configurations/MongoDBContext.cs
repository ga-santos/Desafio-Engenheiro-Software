using Desafio.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Desafio.Infrastructure.Configurations
{
    public class MongoDBContext
    {
        public readonly IMongoDatabase? Database;

        public MongoDBContext(IOptions<MongoConfig> opcoes)
        {
            MongoClient mongoClient = new MongoClient(opcoes.Value.Server);

            if (mongoClient != null)
                Database = mongoClient.GetDatabase(opcoes.Value.Database);
        }

        public IMongoCollection<Pedido> Pedidos
        {
            get
            {
                return Database.GetCollection<Pedido>("pedidos");
            }
        }
    }
}
