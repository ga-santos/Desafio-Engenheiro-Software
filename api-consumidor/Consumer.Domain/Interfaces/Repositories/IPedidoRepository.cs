using Consumer.Domain.Entities;

namespace Consumer.Domain.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        void AdicionarPedido(Pedido? pedido);
    }
}
