using BraidoRental.Core.Infrastructure.Repository;
using BraidoRental.Services.Faturamento.Domain.Contracts.Repositories;
using BraidoRental.Services.Faturamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraidoRental.Services.Infrastructure.Repositories
{
    public class FaturamentoRepository : Repository<CarroFaturamento>, IFaturamentoRepository
    {
        public FaturamentoRepository(BraidoRentalContext context) : base(context)
        {
        }

        public IList<CarroFaturamento> Listar()
        {
            return Query().Include(x => x.Cliente).Include(x => x.CarroLocacao).ThenInclude(x => x.Carro).ToList();
        }

        public  IList<CarroFaturamento> ListarPorCarro(int idCarroLocacao)
        {
            return Query(x => x.CarroLocacao.Id == idCarroLocacao).Include(x => x.Cliente).Include(x => x.CarroLocacao).ThenInclude(x => x.Carro).ToList();
        }

        public  IList<CarroFaturamento>ListarPorCliente(int idCliente)
        {
            return Query(x => x.Cliente.Id == idCliente).Include(x => x.Cliente).Include(x => x.CarroLocacao).ThenInclude(x => x.Carro).ToList();
        }

        public IList<CarroFaturamento> ListarPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return Query(x => dataInicio <= x.Data && x.Data <= dataFim).Include(x => x.Cliente).Include(x => x.CarroLocacao).ThenInclude(x => x.Carro).ToList();
        }

    }
}
