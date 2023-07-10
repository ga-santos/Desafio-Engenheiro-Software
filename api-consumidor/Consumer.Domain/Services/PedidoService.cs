using Consumer.Domain.Entities;
using Consumer.Domain.Interfaces.Repositories;
using Consumer.Domain.Interfaces.Services;

namespace Consumer.Domain.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public void AdicionarPedido(Pedido? pedido)
        {
            _pedidoRepository.AdicionarPedido(pedido);
        }
    }
}
