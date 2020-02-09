using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Locadora.Domain.Exceptions
{
   public class ClienteNaoPossuiLocacaoException: Exception
    {
        public ClienteNaoPossuiLocacaoException() : base("Cliente não possui locação reservada")
        {

        }
    }
}
