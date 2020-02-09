using BraidoRental.Services.Estoque.Domain.Entities;
using BraidoRental.Services.Locadora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Infrastructure.EntityConfigurations
{
    class ClienteEntityTypeConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
               .HasColumnName("Id")
               .ValueGeneratedOnAdd()
               .IsRequired();

            builder.Property(r => r.Nome)
                .HasColumnName("Nome")
                .IsRequired();

            builder.Property(r => r.Email)
                .HasColumnName("Email")
                .IsRequired();

            builder.Property(r => r.CPF)
                .HasColumnName("CPF")
                .IsRequired();

        }

    }
}
