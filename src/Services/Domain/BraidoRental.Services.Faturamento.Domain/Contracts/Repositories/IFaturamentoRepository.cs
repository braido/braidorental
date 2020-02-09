using BraidoRental.Core.Domain.Contract.Repository;
using BraidoRental.Services.Faturamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BraidoRental.Services.Faturamento.Domain.Contracts.Repositories
{
    public interface IFaturamentoRepository : IRepository<CarroFaturamento>
    {
        IList<CarroFaturamento> Listar();

        IList<CarroFaturamento> ListarPorCarro(int idCarroLocacao);

        IList<CarroFaturamento> ListarPorCliente(int idCliente);

        IList<CarroFaturamento> ListarPorPeriodo(DateTime dataInicio, DateTime dataFim);
    }
}
