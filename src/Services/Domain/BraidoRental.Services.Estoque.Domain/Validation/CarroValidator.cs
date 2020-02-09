
using BraidoRental.Services.Estoque.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Estoque.Domain.Validation
{
    public class CarroValidator : AbstractValidator<Carro>
    {

        public CarroValidator()
        {
            RuleFor(x => x.Placa).NotEmpty();
            RuleFor(x => x.Marca).NotEmpty();
            RuleFor(x => x.Modelo).NotEmpty();
        }

    }
}
