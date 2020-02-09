using BraidoRental.Services.Estoque.Domain.Entities;
using BraidoRental.Services.Faturamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Infrastructure.EntityConfigurations
{
    class CarroFaturamentoEntityTypeConfiguration : IEntityTypeConfiguration<CarroFaturamento>
    {
        public void Configure(EntityTypeBuilder<CarroFaturamento> builder)
        {
            builder.ToTable("CarroFaturamento");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
               .HasColumnName("Id")
               .ValueGeneratedOnAdd()
               .IsRequired();

            builder.Property(r => r.Data)
                .HasColumnName("Data")
                .IsRequired();

            builder.Property(r => r.ValorTotalLocacao)
                .HasColumnName("ValorTotalLocacao")
                .IsRequired();

            builder.HasOne(x => x.CarroLocacao)
                .WithMany()
                .IsRequired();

            builder.HasOne(x => x.Cliente)
                .WithMany()
                .IsRequired();
        }

    }
}
