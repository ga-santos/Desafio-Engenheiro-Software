using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Desafio.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IMongoCollection<Pedido> _collection;
        public PedidoRepository(IOptions<MongoConfig> opcoes)
        {
            MongoDBContext contexto = new MongoDBContext(opcoes);
            _collection = contexto.Pedidos;
        }

        public decimal? ObterValorTotalPedido(int codigoPedido)
        {
            Pedido pedido = _collection.Find(pedido => pedido.CodigoPedido == codigoPedido).FirstOrDefault();

            if(pedido != null)
                return pedido.Itens.Sum(item => item.Preco);

            return null;
        }

        public int ObterQuantidadePedidos(int codigoCliente)
        {
            List<Pedido> pedidos = ObterPedidos(codigoCliente);

            return pedidos.Count;
        }

        public List<Pedido> ObterPedidos(int codigoCliente)
        {
            return _collection.Find(pedido => pedido.CodigoCliente == codigoCliente).ToList();
        }
    }
}
