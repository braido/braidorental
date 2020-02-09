using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BraidoRental.Services.Estoque.Domain.Contracts.Application;
using BraidoRental.Services.Estoque.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BraidoRental.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly ILogger<EstoqueController> _logger;
        private readonly IEstoqueService _estoqueService;

        public EstoqueController(
            IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Carro>>> ListarTodos()
        {
            var carros = _estoqueService.ListarCarros();

            return Ok(carros);
        }

        [HttpGet]
        public async Task<ActionResult<IList<Carro>>> ListarDisponiveis()
        {
            var carros = _estoqueService.ListarCarrosDisponiveis();

            return Ok(carros);
        }

        [HttpGet]
        public async Task<ActionResult<Carro>> Obter(int id)
        {
            var carro = _estoqueService.ObterCarro(id);

            if (carro != null)
            {
                return Ok(carro);
            }
            else
            {
                return NotFound(id);
            }
        }
    }
}
