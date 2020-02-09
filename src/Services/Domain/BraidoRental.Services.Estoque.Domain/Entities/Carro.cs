using BraidoRental.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Estoque.Domain.Entities
{
    public class Carro : Entity
    {
        public string Placa { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public bool IsDisponivel { get; set; }

        public void RetirarDoEstoque()
        {
            if (IsDisponivel)
            {
                IsDisponivel = false;
            }
        }
        public void IncluirNoEstoque()
        {
            if (!IsDisponivel)
            {
                IsDisponivel = true;
            }
        }
    }
}
