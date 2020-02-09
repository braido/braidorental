using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BraidoRental.Services.Faturamento.Domain.Contracts.Application;
using BraidoRental.Services.Faturamento.Domain.Model;
using BraidoRental.Services.Locadora.Domain.Contracts.Application;
using BraidoRental.Services.Locadora.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BraidoRental.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FaturamentoController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IFaturamentoService _faturamentoService;

        public FaturamentoController(
            IFaturamentoService faturamentoService)
        {
            _faturamentoService = faturamentoService;
        }

        [HttpGet]
        public async Task<ActionResult<RelatorioFaturamentoCarroModel>> RelatorioFaturamentoPorCarro()
        {
            return await _faturamentoService.FaturamentoPorCarro();
        }

        [HttpGet]
        public async Task<ActionResult<RelatorioFaturamentoAnaliticoModel>> RelatorioFaturamentoAnalitico()
        {
            return await _faturamentoService.FaturamentoAnalitico();
        }
    }
}
