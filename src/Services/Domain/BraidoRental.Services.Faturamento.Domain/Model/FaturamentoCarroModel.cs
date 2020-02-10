using BraidoRental.Services.Faturamento.Domain.Entities;
using BraidoRental.Services.Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BraidoRental.Services.Faturamento.Domain.Model
{
    public class FaturamentoCarroModel
    {
        public CarroLocacao Carro { get; set; }

        public int Quantidade { get; set; }

        public decimal ValorFaturado { get; set; }

    }
}
