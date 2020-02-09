using BraidoRental.Services.Estoque.Domain.Entities;
using BraidoRental.Services.Locadora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Infrastructure.EntityConfigurations
{
    class CarroLocacaoEntityTypeConfiguration : IEntityTypeConfiguration<CarroLocacao>
    {
        public void Configure(EntityTypeBuilder<CarroLocacao> builder)
        {
            builder.ToTable("CarroLocacao");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
               .HasColumnName("Id")
               .ValueGeneratedOnAdd()
               .IsRequired();

            builder.Property(r => r.ValorDiario)
                .HasColumnName("ValorDiario")
                .IsRequired();

            builder.HasOne(x => x.Carro)
                .WithOne()
                .IsRequired();
        }

    }
}
