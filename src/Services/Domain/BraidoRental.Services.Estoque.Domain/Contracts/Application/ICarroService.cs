using BraidoRental.Services.Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Estoque.Domain.Contracts.Application
{
    public interface IEstoqueService
    {
        IList<Carro> ListarCarros();

        IList<Carro> ListarCarrosDisponiveis();

        Carro ObterCarro(int id);

        Carro SalvarCarro(Carro carro);

        Carro EfetuarRetirada(Carro carro);

        Carro EfetuarDevolucao(Carro carro);
    }
}
