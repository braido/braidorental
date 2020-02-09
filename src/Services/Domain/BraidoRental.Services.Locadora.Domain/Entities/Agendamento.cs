using BraidoRental.Core.Domain.Entities;
using BraidoRental.Services.Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BraidoRental.Services.Locadora.Domain.Entities
{
    public class Agendamento : Entity
    {
        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public CarroLocacao CarroLocacao { get; set; }

        public Cliente Cliente { get; set; }

        public bool CarroComCliente { get; set; }

        public decimal ValorTotal { get; set; }

        public decimal CalcularValorTotal()
        {
            var diascorridos = (int)(DataFim.Date - DataInicio.Date).TotalDays + 1;

            ValorTotal = CarroLocacao.ValorDiario * diascorridos;

            return ValorTotal;
        }
    }
}
