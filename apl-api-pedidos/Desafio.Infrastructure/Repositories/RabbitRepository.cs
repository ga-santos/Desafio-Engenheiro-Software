using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Desafio.Infrastructure.Repositories
{
    public class RabbitRepository : IRabbitRepository
    {
        private readonly RabbitConfig _rabbitConfig;

        public RabbitRepository(IOptions<RabbitConfig> opcoes)
        {
            _rabbitConfig = new RabbitConfig
            {
                HostName = opcoes.Value.HostName,
                Port = opcoes.Value.Port,
                Password = opcoes.Value.Password,
                UserName = opcoes.Value.UserName,
                Queue = opcoes.Value.Queue
            };
        }
        public void PublicarPedido(Pedido pedido)
        {
            var factory = new ConnectionFactory { 
                HostName = _rabbitConfig.HostName,
                UserName = _rabbitConfig.UserName,
                Password = _rabbitConfig.Password,
                Port = _rabbitConfig.Port
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _rabbitConfig.Queue,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string jsonPedido = JsonSerializer.Serialize(pedido);
            var body = Encoding.UTF8.GetBytes(jsonPedido);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: _rabbitConfig.Queue,
                                 basicProperties: null,
                                 body: body);
        }
    }
}
