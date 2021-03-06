﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BraidoRental.API.Infrastructure;
using BraidoRental.Services.Locadora.Domain.Contracts.Application;
using BraidoRental.Services.Locadora.Domain.Entities;
using BraidoRental.Services.Locadora.Domain.Exceptions;
using BraidoRental.Services.Locadora.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BraidoRental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

            return Ok(ResponseObject.SucessoObj(carros));
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<CarroLocacao>> Obter(int id)
        {
            var carro = _locacaoService.ObterCarro(id);

            if (carro != null)
            {
                return Ok(ResponseObject.SucessoObj(carro));
            }
            else
            {
                return NotFound(ResponseObject.FalhaMsg);
            }
        }

        [HttpPost("realizaragendamento")]
        public async Task<ActionResult<Agendamento>> RealizarAgendamento(AgendamentoModel model)
        {
            try
            {
                var agendamento = _locacaoService.RealizarAgendamento(model);

                return Ok(ResponseObject.SucessoObj(agendamento));
            }
            catch (DataLocacaoIndisponivelException ex)
            {
                return NotFound(ResponseObject.FalhaMsgCustom(ex.Message));
            }
        }

        [HttpPost("simularagendamento")]
        public async Task<ActionResult<Agendamento>> SimularAgendamento(SimulacaoAgendamentoModel model)
        {
            var agendamento = _locacaoService.SimularAgendamento(model);

            return Ok(ResponseObject.SucessoObj(agendamento));
        }

        [HttpPost("realizarretirada")]
        public async Task<ActionResult<Agendamento>> RealizarRetiradaCarro(RetiradaModel model)
        {
            try
            {
                _locacaoService.RealizarRetiradaCarro(model);

                return Ok(ResponseObject.SucessoMsg);
            }
            catch (DataLocacaoIndisponivelException ex)
            {
                return NotFound(ResponseObject.FalhaMsgCustom(ex.Message));
            }
        }

        [HttpPost("realizardevolucao")]
        public async Task<ActionResult<Agendamento>> RealizarDevolucaoaCarro(DevolucaoModel model)
        {
            try
            {
                _locacaoService.RealizarDevolucaoaCarro(model);

                return Ok(ResponseObject.SucessoMsg);
            }
            catch (DataLocacaoIndisponivelException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CarroLocacao>> Salvar(CarroLocacao carroLocacao)
        {
            carroLocacao = _locacaoService.SalvarCarro(carroLocacao);

            return Ok(ResponseObject.SucessoObj(carroLocacao));
        }
    }
}
