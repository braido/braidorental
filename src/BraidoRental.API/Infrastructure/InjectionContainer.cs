using Autofac;
using BraidoRental.Core.Domain.Contract.Repository;
using BraidoRental.Core.Infrastructure.Repository;
using BraidoRental.Services.Estoque.Domain.Contracts.Repositories;
using BraidoRental.Services.Estoque.Domain.Entities;
using BraidoRental.Services.Estoque.Domain.Validation;
using BraidoRental.Services.Faturamento.Domain.Contracts.Repositories;
using BraidoRental.Services.Infrastructure.Repositories;
using BraidoRental.Services.Locadora.Domain.Contracts.Application;
using BraidoRental.Services.Locadora.Domain.Entities;
using BraidoRental.Services.Application.Services;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BraidoRental.Services.Estoque.Domain.Contracts.Application;
using BraidoRental.Services.Faturamento.Domain.Contracts.Application;

namespace BraidoRental.API.Infrastructure
{
    public class InjectionContainer : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarroRepository>()
                .As<ICarroRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CarroLocacaoRepository>()
                .As<ICarroLocacaoRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FaturamentoRepository>()
                .As<IFaturamentoRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AgendamentoRepository>()
                .As<IAgendamentoRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ClienteRepository>()
                .As<IRepository<Cliente>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ClienteService>()
                .As<IClienteService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EstoqueService>()
                .As<IEstoqueService>()
                .InstancePerLifetimeScope();
                  
            builder.RegisterType<FaturamentoService>()
                .As<IFaturamentoService>()
                .InstancePerLifetimeScope();
                  
            builder.RegisterType<LocacaoService>()
                .As<ILocacaoService>()
                .InstancePerLifetimeScope();
        }
    }
}
