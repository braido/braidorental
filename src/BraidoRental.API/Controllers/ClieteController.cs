﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BraidoRental.Services.Estoque.Domain.Contracts.Application;
using BraidoRental.Services.Estoque.Domain.Entities;
using BraidoRental.Services.Locadora.Domain.Contracts.Application;
using BraidoRental.Services.Locadora.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BraidoRental.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteService _clienteService;

        public ClienteController(
            IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Cliente>>> Listar()
        {
            var clientes = _clienteService.Listar();

            return Ok(clientes);
        }

        [HttpGet]
        public async Task<ActionResult<Cliente>> Obter(int id)
        {
            var cliente = _clienteService.Obter(id);

            if (cliente != null)
            {
                return Ok(cliente);
            }
            else
            {
                return NotFound(id);
            }
        }

        public async Task<ActionResult<Cliente>> Salvar(Cliente cliente)
        {
            cliente = _clienteService.Salvar(cliente);

            return Ok(cliente);
        }
}
}
