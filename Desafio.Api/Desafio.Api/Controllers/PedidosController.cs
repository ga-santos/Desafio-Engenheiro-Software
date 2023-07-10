using Desafio.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Application.Controllers
{
    [Route("api-desafio/Pedidos")]
    public class PedidosController : Controller
    {
        private readonly IPedidoService _pedidoService;
        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("ValorTotal")]
        public IActionResult ObterValorTotal([FromQuery] int codigoPedido)
        {
            return Ok(new { ValorTotalPedido = _pedidoService.ObterValorTotalPedido(codigoPedido) });
        }

        [HttpGet("Quantidade")]
        public IActionResult ObterQuantidadePedidos([FromQuery] int codigoCliente)
        {
            return Ok(new { QtdPedidos = _pedidoService.ObterQuantidadePedidos(codigoCliente) });
        }

        [HttpGet("")]
        public IActionResult ObterPedidos([FromQuery] int codigoCliente)
        {
            return Ok(new { Pedidos = _pedidoService.ObterPedidos(codigoCliente) });
        }
    }
}
