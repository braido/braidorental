using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Locadora.Domain.Model
{
    public class SimulacaoAgendamentoModel
    {
        public int IdCarro { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }
    }
}
