using BraidoRental.Core.Domain.Entities;
using BraidoRental.Services.Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Faturamento.Domain.Entities
{
    public class CarroFaturamento : Entity
    {
        public DateTime Data { get; protected set; }

        public CarroLocacao CarroLocacao { get; protected set; }

        public Cliente Cliente { get; protected set; }

        public decimal ValorTotalLocacao { get; protected set; }

        public CarroFaturamento(CarroLocacao carro, Cliente cliente, decimal valor)
        {
            CarroLocacao = carro;
            Cliente = cliente;
            ValorTotalLocacao = valor;
            Data = DateTime.Now;
        }
    }
}
