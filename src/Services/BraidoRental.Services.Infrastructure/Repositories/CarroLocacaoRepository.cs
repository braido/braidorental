using BraidoRental.Core.Domain.Contract.Repository;
using BraidoRental.Core.Infrastructure.Repository;
using BraidoRental.Core.Infrastructure.Repository.Extensions;
using BraidoRental.Services.Locadora.Domain.Contracts.Application;
using BraidoRental.Services.Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace BraidoRental.Services.Infrastructure.Repositories
{
    public class CarroLocacaoRepository : Repository<CarroLocacao>, ICarroLocacaoRepository
    {
        public CarroLocacaoRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IList<CarroLocacao> Listar()
        {
            return Query().Include(x => x.Carro).ToList();
        }
    }
}
