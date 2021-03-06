﻿using BraidoRental.Core.Domain.Contract.Repository;
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
        public CarroLocacaoRepository(BraidoRentalContext context) : base(context)
        {
        }

        public IList<CarroLocacao> Listar()
        {
            return Query().Include(x => x.Agendamentos).Include(x => x.Carro).ToList();
        }

        public CarroLocacao Obter(int id)
        {
            return Query(x => x.Id == id).Include(x => x.Agendamentos).Include(x => x.Carro).FirstOrDefault();
        }
    }
}
