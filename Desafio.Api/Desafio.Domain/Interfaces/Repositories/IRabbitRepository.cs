using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Interfaces.Repositories
{
    public interface IRabbitRepository
    {
        void PublicarPedido(Pedido pedido);
    }
}
