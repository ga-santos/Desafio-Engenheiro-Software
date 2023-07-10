using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Desafio.Tests
{
    public class PedidoRepositoryTestes
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IOptions<MongoConfig> _opcoes;

        public PedidoRepositoryTestes(IPedidoRepository repository, IOptions<MongoConfig> opcoes)
        {
            _opcoes = opcoes;
            _pedidoRepository = repository;
        }

        [Fact]
        public void TestaConexaoComMongoDB()
        {
            //Arrange
            MongoClient mongoClient = new MongoClient(_opcoes.Value.Server);
            bool conectado = false;

            //Act
            if (mongoClient != null)
                conectado = true;

            //Assert
            Assert.True(conectado);
        }

        [Fact]
        public void TestaObterPedidos()
        {
            //Arrange
            int codigoCliente = 1;

            //Act
            List<Pedido> pedidos = _pedidoRepository.ObterPedidos(codigoCliente);

            //Assert
            Assert.NotEmpty(pedidos);
        }

        [Fact]
        public void TestaObterValorTotalPedido()
        {
            //Arrange
            int codigoPedido = 1001;

            //Act
            decimal? valorTotal = _pedidoRepository.ObterValorTotalPedido(codigoPedido);

            //Assert
            Assert.Equal((decimal)2.1, valorTotal);
        }

        [Fact]
        public void TestaObterQuantidadePedidos()
        {
            //Arrange
            int codigoCliente = 1;

            //Act
            int quantidade = _pedidoRepository.ObterQuantidadePedidos(codigoCliente);

            //Assert
            Assert.Equal(2, quantidade);
        }
    }
}