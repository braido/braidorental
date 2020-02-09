using BraidoRental.Core.Infrastructure.Repository;
using BraidoRental.Services.Estoque.Domain.Contracts.Repositories;
using BraidoRental.Services.Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BraidoRental.Services.Infrastructure.Repositories
{
    public class CarroRepository : Repository<Carro>, ICarroRepository
    {
        public CarroRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IList<Carro> ListarDisponiveis()
        {
            return Query(x => x.IsDisponivel).ToList();
        }
    }
}
