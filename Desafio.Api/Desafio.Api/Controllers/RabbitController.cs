using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Application.Controllers
{
    [Route("api-desafio/Rabbit")]
    public class RabbitController : Controller
    {
        private readonly IRabbitService _rabbitService;
        public RabbitController(IRabbitService rabbitService)
        {
            _rabbitService = rabbitService;
        }

        [HttpPost]
        public IActionResult PublicaPedido([FromBody] Pedido pedido)
        {
            _rabbitService.PublicarPedido(pedido);

            return Ok();
        }
    }
}
