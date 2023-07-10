using Desafio.Domain.Entities;

namespace Desafio.Domain.Interfaces.Services
{
    public interface IPedidoService
    {
        decimal? ObterValorTotalPedido(int codigoPedido);

        int ObterQuantidadePedidos(int codigoCliente);

        List<Pedido> ObterPedidos(int codigoCliente);
    }
}
