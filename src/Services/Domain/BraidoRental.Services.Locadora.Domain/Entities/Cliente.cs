using BraidoRental.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Locadora.Domain.Entities
{
   public class Cliente : Entity
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

    }
}
