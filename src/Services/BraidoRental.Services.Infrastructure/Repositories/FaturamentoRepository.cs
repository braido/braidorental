using BraidoRental.Core.Infrastructure.Repository;
using BraidoRental.Services.Faturamento.Domain.Contracts.Repositories;
using BraidoRental.Services.Faturamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BraidoRental.Services.Infrastructure.Repositories
{
    public class FaturamentoRepository : Repository<CarroFaturamento>, IFaturamentoRepository
    {
        public FaturamentoRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IList<CarroFaturamento>> Listar()
        {
            return await Query().Include(x => x.Cliente).Include(x => x.CarroLocacao).ThenInclude(x => x.Carro).ToListAsync();
        }

        public async Task<IList<CarroFaturamento>> ListarPorCarro(int idCarroLocacao)
        {
            return await Query(x => x.CarroLocacao.Id == idCarroLocacao).Include(x => x.Cliente).Include(x => x.CarroLocacao).ThenInclude(x => x.Carro).ToListAsync();
        }

        public async Task<IList<CarroFaturamento>> ListarPorCliente(int idCliente)
        {
            return await Query(x => x.Cliente.Id == idCliente).Include(x => x.Cliente).Include(x => x.CarroLocacao).ThenInclude(x => x.Carro).ToListAsync();
        }

        public async Task<IList<CarroFaturamento>> ListarPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return await Query(x => dataInicio <= x.Data && x.Data <= dataFim).Include(x => x.Cliente).Include(x => x.CarroLocacao).ThenInclude(x => x.Carro).ToListAsync();
        }

    }
}
