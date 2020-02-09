using BraidoRental.Core.Domain.Contract.Repository;
using BraidoRental.Core.Infrastructure.Repository;
using BraidoRental.Services.Estoque.Domain.Entities;
using BraidoRental.Services.Faturamento.Domain.Entities;
using BraidoRental.Services.Infrastructure.EntityConfigurations;
using BraidoRental.Services.Locadora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BraidoRental.Services.Infrastructure
{
    public class BraidoRentalContext : UnitOfWork
    {
        public DbSet<Carro> Carros { get; set; }

        public DbSet<CarroLocacao> CarrosLocacacao { get; set; }

        public DbSet<Agendamento> Agendamentos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<CarroFaturamento> CarroFaturamentos { get; set; }

        public BraidoRentalContext(DbContextOptions<BraidoRentalContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CarroEntityTypeConfiguration());
            builder.ApplyConfiguration(new CarroLocacaoEntityTypeConfiguration());
            builder.ApplyConfiguration(new ClienteEntityTypeConfiguration());
            builder.ApplyConfiguration(new AgendamentoEntityTypeConfiguration());
            builder.ApplyConfiguration(new CarroFaturamentoEntityTypeConfiguration());
        }
    }

    public class BraidoRentalContextDesignFactory : IDesignTimeDbContextFactory<BraidoRentalContext>
    {
        public BraidoRentalContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration["ConnectionString"];
            var optionsBuilder = new DbContextOptionsBuilder<BraidoRentalContext>()
                .UseSqlServer(connectionString);

            return new BraidoRentalContext(optionsBuilder.Options);
        }
    }
}
