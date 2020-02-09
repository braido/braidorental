using BraidoRental.Services.Estoque.Domain.Entities;
using BraidoRental.Services.Infrastructure;
using BraidoRental.Services.Locadora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BraidoRental.API.Infrastructure
{
    public class BraidoRentalContextSeed
    {
        public async Task SeedAsync(BraidoRentalContext context)
        {
            using (context)
            {
                context.Database.Migrate();

                if (!context.CarrosLocacacao.Any())
                {
                    context.CarrosLocacacao.AddRange(GetPredefinedCarrosLocacao());

                    await context.SaveChangesAsync();
                }

                if (!context.Clientes.Any())
                {
                    context.Clientes.AddRange(GetPredefinedClietes());

                    await context.SaveChangesAsync();
                }
            }
        }
        private IEnumerable<CarroLocacao> GetPredefinedCarrosLocacao()
        {
            return new List<CarroLocacao>()
                {
                    new CarroLocacao()
                    {
                        Carro = new Carro() {
                            Marca = "Fiat",
                            Modelo = "Argo",
                            Placa= "ABC-1234",
                            IsDisponivel = true
                        },
                        ValorDiario = 50.00M
                    },

                    new CarroLocacao()
                    {
                        Carro = new Carro() {
                            Marca = "Renout",
                            Modelo = "Sandero",
                            Placa = "XYZ-0000",
                            IsDisponivel = true
                        },
                        ValorDiario = 40.00M
                    }
                };
        }

        private IEnumerable<Cliente> GetPredefinedClietes()
        {
            return new List<Cliente>()
            {
                new Cliente()
                {
                    Nome = "Braido",
                    CPF = "12345678909",
                    Email ="felipe_flp8@hotmail.com"
                },
                new Cliente()
                {
                    Nome = "João",
                    CPF = "12345678909",
                    Email ="joao@hotmail.com"
                },
                new Cliente()
                {
                    Nome = "Maria",
                    CPF = "12345678909",
                    Email ="maria@hotmail.com"
                }
            };
        }
    }
}