using BraidoRental.Core.Domain.Contract.Repository;
using BraidoRental.Services.Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Estoque.Domain.Contracts.Repositories
{
    public interface ICarroRepository : IRepository<Carro>
    {
        IList<Carro> ListarDisponiveis();
    }
}
