using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infrastructure.Configurations;
using Desafio.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                 .AddEnvironmentVariables()
            .Build();

            services.Configure<MongoConfig>(opcoes =>
            {
                opcoes.Database = config.GetSection("ConnectionString:Database").Value;
                opcoes.Server = config.GetSection("ConnectionString:Server").Value;
            });

            services.AddTransient<IPedidoRepository, PedidoRepository>();
        }
    }
}
