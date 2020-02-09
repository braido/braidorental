using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Locadora.Domain.Exceptions
{
   public class DataLocacaoIndisponivelException : Exception
    {
        public DataLocacaoIndisponivelException() : base("Data selecionada para locação indisponível")
        {

        }
    }
}
