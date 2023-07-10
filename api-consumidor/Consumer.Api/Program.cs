using Consumer.Api.Consumer;
using Consumer.Domain.Interfaces.Repositories;
using Consumer.Domain.Interfaces.Services;
using Consumer.Domain.Services;
using Consumer.Infrastructure.Configurations;
using Consumer.Infrastructure.Repositories;
using Desafio.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoConfig>(opcoes =>
{
    opcoes.Database = builder.Configuration.GetSection("ConnectionString:Database").Value;
    opcoes.Server = builder.Configuration.GetSection("ConnectionString:Server").Value;
});

builder.Services.Configure<RabbitConfig>(opcoes =>
{
    opcoes.HostName = builder.Configuration.GetSection("RabbitMQ:HostName").Value;
    opcoes.UserName = builder.Configuration.GetSection("RabbitMQ:UserName").Value;
    opcoes.Password = builder.Configuration.GetSection("RabbitMQ:Password").Value;
    opcoes.Port = Int32.Parse(builder.Configuration.GetSection("RabbitMQ:Port").Value);
    opcoes.Queue = builder.Configuration.GetSection("RabbitMQ:Queue").Value;
});

builder.Services.AddTransient<IPedidoService, PedidoService>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddHostedService<RabbitConsumer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
