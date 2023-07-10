using Consumer.Domain.Entities;

namespace Consumer.Domain.Interfaces.Services
{
    public interface IPedidoService
    {
        void AdicionarPedido(Pedido? pedido);
    }
}
