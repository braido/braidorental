﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BraidoRental.API.Infrastructure;
using BraidoRental.Services.Estoque.Domain.Contracts.Application;
using BraidoRental.Services.Estoque.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BraidoRental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
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

            return Ok(ResponseObject.SucessoObj(carros));
        }

        [HttpGet("disponiveis")]
        public async Task<ActionResult<IList<Carro>>> ListarDisponiveis()
        {
            var carros = _estoqueService.ListarCarrosDisponiveis();

            return Ok(ResponseObject.SucessoObj(carros));
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<Carro>> Obter(int id)
        {
            var carro = _estoqueService.ObterCarro(id);

            if (carro != null)
            {
                return Ok(ResponseObject.SucessoObj(carro));
            }
            else
            {
                return NotFound(ResponseObject.FalhaMsg);
            }
        }
    }
}
