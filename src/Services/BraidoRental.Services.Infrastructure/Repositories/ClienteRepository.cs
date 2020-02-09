using BraidoRental.Core.Domain.Contract.Repository;
using BraidoRental.Core.Infrastructure.Repository;
using BraidoRental.Services.Estoque.Domain.Contracts.Repositories;
using BraidoRental.Services.Estoque.Domain.Entities;
using BraidoRental.Services.Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BraidoRental.Services.Infrastructure.Repositories
{
    public class ClienteRepository : Repository<Cliente>,  IRepository<Cliente>
    {
        public ClienteRepository(BraidoRentalContext context) : base(context)
        {
        }
    }
}
