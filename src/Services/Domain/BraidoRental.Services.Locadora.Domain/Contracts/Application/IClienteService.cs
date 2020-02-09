using BraidoRental.Services.Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Locadora.Domain.Contracts.Application
{
    public interface IClienteService
    {
        IList<Cliente> Listar();

        Cliente Obter(int id);

        Cliente Salvar(Cliente cliente);
    }
}
