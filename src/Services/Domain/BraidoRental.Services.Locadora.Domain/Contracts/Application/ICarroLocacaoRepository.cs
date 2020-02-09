using BraidoRental.Core.Domain.Contract.Repository;
using BraidoRental.Services.Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Locadora.Domain.Contracts.Application
{
    public interface ICarroLocacaoRepository : IRepository<CarroLocacao>
    {
        IList<CarroLocacao> Listar();
    }
}
