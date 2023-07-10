using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Services
{
    public class RabbitService : IRabbitService
    {
        private readonly IRabbitRepository _rabbitRepository;

        public RabbitService(IRabbitRepository rabbitRepository)
        {
            _rabbitRepository = rabbitRepository;
        }

        public void PublicarPedido(Pedido pedido)
        {
            _rabbitRepository.PublicarPedido(pedido);
        }
    }
}
