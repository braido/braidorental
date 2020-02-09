using BraidoRental.Services.Locadora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Infrastructure.EntityConfigurations
{
    public class AgendamentoEntityTypeConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("Agendamento");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
               .HasColumnName("Id")
               .ValueGeneratedOnAdd()
               .IsRequired();

            builder.Property(r => r.DataInicio)
                .HasColumnName("DataInicio")
                .IsRequired();

            builder.Property(r => r.DataFim)
                .HasColumnName("DataFim")
                .IsRequired(); 
            
            builder.Property(r => r.CarroComCliente)
                .HasColumnName("CarroComCliente")
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasOne(x => x.Cliente)
                .WithMany()
                .IsRequired();
        }
    }
}
