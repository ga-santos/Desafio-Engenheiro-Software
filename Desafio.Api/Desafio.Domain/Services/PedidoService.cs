using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Domain.Interfaces.Services;

namespace Desafio.Domain.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public decimal? ObterValorTotalPedido(int codigoPedido)
        {
           return _pedidoRepository.ObterValorTotalPedido(codigoPedido);
        }

        public int ObterQuantidadePedidos(int codigoCliente)
        {
            return _pedidoRepository.ObterQuantidadePedidos(codigoCliente);
        }

        public List<Pedido> ObterPedidos(int codigoCliente)
        {
            return _pedidoRepository.ObterPedidos(codigoCliente);
        }
    }
}
