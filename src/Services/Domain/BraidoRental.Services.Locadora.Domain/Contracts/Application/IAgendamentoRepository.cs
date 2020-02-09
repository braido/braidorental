using BraidoRental.Core.Domain.Contract.Repository;
using BraidoRental.Services.Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Locadora.Domain.Contracts.Application
{
    public interface IAgendamentoRepository : IRepository<Agendamento>
    {
        Agendamento BuscarAgendamentoPendente(int idCarroLocacao, int idCliente);
        Agendamento BuscarAgendamentoEmAndamento(int idCarroLocacao, int idCliente);
    }
}
