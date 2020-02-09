using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BraidoRental.Services.Locadora.Domain.Contracts.Application;
using BraidoRental.Services.Locadora.Domain.Entities;
using BraidoRental.Services.Locadora.Domain.Exceptions;
using BraidoRental.Services.Locadora.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BraidoRental.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocacaoController : ControllerBase
    {
        private readonly ILogger<LocacaoController> _logger;
        private readonly ILocacaoService _locacaoService;

        public LocacaoController(
            ILocacaoService locacaoService)
        {
            _locacaoService = locacaoService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<CarroLocacao>>> ListarCarros()
        {
            var carros = _locacaoService.ListarCarros();

            return Ok(carros);
        }

        [HttpGet]
        public async Task<ActionResult<CarroLocacao>> Obter(int id)
        {
            var carro = _locacaoService.ObterCarro(id);

            if (carro != null)
            {
                return Ok(carro);
            }
            else
            {
                return NotFound(id);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Agendamento>> RealizarAgendamento(AgendamentoModel model)
        {
            try
            {
                var agendamento = _locacaoService.RealizarAgendamento(model);

                return Ok(agendamento);
            }
            catch (DataLocacaoIndisponivelException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Agendamento>> SimularAgendamento(SimulacaoAgendamentoModel model)
        {
            var agendamento = _locacaoService.SimularAgendamento(model);

            return Ok(agendamento);
        }

        [HttpPost]
        public async Task<ActionResult<Agendamento>> RealizarRetiradaCarro(RetiradaModel model)
        {
            try
            {
                _locacaoService.RealizarRetiradaCarro(model);

                return Ok();
            }
            catch (DataLocacaoIndisponivelException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Agendamento>> RealizarDevolucaoaCarro(DevolucaoModel model)
        {
            try
            {
                _locacaoService.RealizarDevolucaoaCarro(model);

                return Ok();
            }
            catch (DataLocacaoIndisponivelException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
