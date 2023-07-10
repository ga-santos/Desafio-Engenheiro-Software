using Consumer.Domain.Entities;
using Consumer.Domain.Interfaces.Services;
using Consumer.Domain.Services;
using Desafio.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Consumer.Api.Consumer
{
    public class RabbitConsumer : BackgroundService
    {
        private readonly IPedidoService _pedidoService;
        private readonly RabbitConfig _rabbitConfig;
        private readonly IConnection _connection;
        private readonly IServiceProvider _serviceProvider;
        private readonly IModel _channel;

        public RabbitConsumer(IOptions<RabbitConfig> opcoes, IPedidoService pedidoService, IServiceProvider serviceProvider)
        {
            _pedidoService = pedidoService;
            _serviceProvider = serviceProvider;

            _rabbitConfig = new RabbitConfig
            {
                HostName = opcoes.Value.HostName,
                Port = opcoes.Value.Port,
                Password = opcoes.Value.Password,
                UserName = opcoes.Value.UserName,
                Queue = opcoes.Value.Queue
            };

            var factory = new ConnectionFactory
            {
                HostName = _rabbitConfig.HostName,
                UserName = _rabbitConfig.UserName,
                Password = _rabbitConfig.Password,
                Port = _rabbitConfig.Port
            };

            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _rabbitConfig.Queue,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var bodyString = Encoding.UTF8.GetString(body);

                Pedido? pedido = JsonSerializer.Deserialize<Pedido>(bodyString);

                _pedidoService.AdicionarPedido(pedido);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(queue: _rabbitConfig.Queue,
                                 false,
                                 consumer: consumer);

            return Task.CompletedTask;
        }
    }
}
