using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Locadora.Domain.Model
{
    public class AgendamentoModel
    {
        public int IdCarro { get; set; }

        public int IdCliente { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }
    }
}
