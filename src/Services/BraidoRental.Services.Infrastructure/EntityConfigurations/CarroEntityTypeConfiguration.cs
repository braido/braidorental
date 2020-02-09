using BraidoRental.Services.Estoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Infrastructure.EntityConfigurations
{
    class CarroEntityTypeConfiguration : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.ToTable("Carro");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
               .HasColumnName("Id")
               .ValueGeneratedOnAdd()
               .IsRequired();

            builder.Property(r => r.Placa)
                .HasColumnName("Placa")
                .IsRequired();

            builder.Property(r => r.Marca)
                .HasColumnName("Marca")
                .IsRequired();

            builder.Property(r => r.Modelo)
                .HasColumnName("Modelo")
                .IsRequired();

            builder.Property(r => r.IsDisponivel)
                .HasColumnName("IsDisponivel")
                .HasDefaultValue(true)
                .IsRequired();
        }

    }
}
