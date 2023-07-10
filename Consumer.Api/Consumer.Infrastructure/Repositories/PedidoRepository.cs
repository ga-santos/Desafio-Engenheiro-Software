using Consumer.Domain.Entities;
using Consumer.Domain.Interfaces.Repositories;
using Consumer.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Consumer.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IMongoCollection<Pedido> _collection;
        public PedidoRepository(IOptions<MongoConfig> opcoes)
        {
            MongoDBContext contexto = new MongoDBContext(opcoes);
            _collection = contexto.Pedidos;
        }

        public void AdicionarPedido(Pedido? pedido)
        {
            if(pedido != null)
                _collection.InsertOne(pedido);
        }
    }
}
