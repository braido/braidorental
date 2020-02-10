using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BraidoRental.API.Infrastructure;
using BraidoRental.Services.Faturamento.Domain.Contracts.Application;
using BraidoRental.Services.Faturamento.Domain.Model;
using BraidoRental.Services.Locadora.Domain.Contracts.Application;
using BraidoRental.Services.Locadora.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BraidoRental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FaturamentoController : ControllerBase
    {
        private readonly IFaturamentoService _faturamentoService;

        public FaturamentoController(
            IFaturamentoService faturamentoService)
        {
            _faturamentoService = faturamentoService;
        }

        [HttpGet("relfaturamentoporcarro")]
        public async Task<ActionResult<RelatorioFaturamentoCarroModel>> RelatorioFaturamentoPorCarro()
        {
            return Ok(ResponseObject.SucessoObj( _faturamentoService.FaturamentoPorCarro()));
        }

        [HttpGet("relfaturamentoanalitico")]
        public async Task<ActionResult<RelatorioFaturamentoAnaliticoModel>> RelatorioFaturamentoAnalitico()
        {
            return Ok(ResponseObject.SucessoObj(_faturamentoService.FaturamentoAnalitico()));
        }
    }
}
