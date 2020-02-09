using BraidoRental.Core.Domain.Entities;
using BraidoRental.Services.Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BraidoRental.Services.Locadora.Domain.Entities
{
    public class CarroLocacao : Entity
    {
        public Carro Carro { get; set; }

        public decimal ValorDiario { get; set; }

        public IList<Agendamento> Agendamentos { get; set; }

        public IList<Agendamento> AgendamentosFuturos()
        {
            return Agendamentos.Where(x => x.DataFim.Date > DateTime.Now.Date).ToList();
        }

        public bool VerificarDisponibilidadeParaLocacao(DateTime dataInicio, DateTime dataFim)
        {
            return AgendamentosFuturos().All(x => dataInicio > x.DataFim || dataFim < x.DataInicio);
        }

        public bool VerificarDisponibilidadeRetirada()
        {
            return Carro.IsDisponivel;
        }
    }
}
