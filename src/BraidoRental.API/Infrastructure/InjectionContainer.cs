using Autofac;
using BraidoRental.Core.Domain.Contract.Repository;
using BraidoRental.Core.Infrastructure.Repository;
using BraidoRental.Services.Estoque.Domain.Entities;
using BraidoRental.Services.Estoque.Domain.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BraidoRental.API.Infrastructure
{
    public class InjectionContainer : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Repository<Carro>>()
                .As<IRepository<Carro>>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CarroValidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();
        }
    }
}
