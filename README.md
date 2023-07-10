# Desafio-Engenheiro-Software

Desafio de Engenharia de Software com o objetivo de processar pedidos utilizando uma base de dados (MongoDB) e um mensageiro (RabbitMQ).

## Rodando localmente

Clone o projeto

Entre no diretório da API REST

```bash
  cd apl-api-pedidos/Desafio.api
```

Inicie a API REST

```bash
  dotnet run
```
----

Entre no diretório do Microserviço Consumidor

```bash
  cd api-consumidor/Consumer.Api
```

Inicie o Microserviço

```bash
  dotnet run
```
----
Entre no diretório do RabbitMQ

```bash
  cd rabbit-mq
```

Inicie o Docker

```bash
  docker-compose up
```
----
Base de dados está no MongoDB Cloud e pode ser acessada através de sua string de conexão.
