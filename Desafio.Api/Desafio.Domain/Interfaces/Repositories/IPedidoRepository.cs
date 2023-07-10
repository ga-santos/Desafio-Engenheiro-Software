using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Interfaces.Repositories
{
    public interface IPedidoRepository { 
        decimal? ObterValorTotalPedido(int codigoPedido);

        int ObterQuantidadePedidos(int codigoCliente);

        List<Pedido> ObterPedidos(int codigoCliente);
    }
}
