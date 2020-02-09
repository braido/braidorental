using BraidoRental.Core.Domain.Contract.Repository;
using BraidoRental.Core.Infrastructure.Repository;
using BraidoRental.Core.Infrastructure.Repository.Extensions;
using BraidoRental.Services.Locadora.Domain.Contracts.Application;
using BraidoRental.Services.Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BraidoRental.Services.Infrastructure.Repositories
{
    public class AgendamentoRepository : Repository<Agendamento>, IAgendamentoRepository
    {
        public AgendamentoRepository(BraidoRentalContext context) : base(context)
        {
        }

        public Agendamento BuscarAgendamentoEmAndamento(int idCarroLocacao, int idCliente)
        {
            var agora = DateTime.Now;

            return Query(x =>
                x.CarroLocacao.Id == idCarroLocacao &&
                x.Cliente.Id == idCliente &&
                x.DataInicio < agora &&
                x.DataFim > agora &&
                x.CarroComCliente).FirstOrDefault();
        }

        public Agendamento BuscarAgendamentoPendente(int idCarroLocacao, int idCliente)
        {
            var agora = DateTime.Now;

            return Query(x =>
                x.CarroLocacao.Id == idCarroLocacao &&
                x.Cliente.Id == idCliente &&
                x.DataInicio < agora &&
                x.DataFim > agora &&
                !x.CarroComCliente).FirstOrDefault();
        }
    }
}
