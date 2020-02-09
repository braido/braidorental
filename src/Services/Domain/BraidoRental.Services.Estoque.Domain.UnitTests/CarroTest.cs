using BraidoRental.Services.Estoque.Domain.Entities;
using System;
using Xunit;

namespace BraidoRental.Services.Estoque.Domain.UnitTests
{
    public class CarroTest
    {
        [Fact]
        public void retirar_carro_disponivel_do_estoque_()
        {
            bool valorEsperado = false;


            var carro = new Carro()
            {
                IsDisponivel = true
            };

            carro.RetirarDoEstoque();

            Assert.Equal(valorEsperado, carro.IsDisponivel) ;

        }

        [Fact]
        public void retirar_carro_indisponivel_do_estoque_()
        {
            bool valorEsperado = false;
            
            var carro = new Carro()
            {
                IsDisponivel = false
            };

            carro.RetirarDoEstoque();

            Assert.Equal(valorEsperado, carro.IsDisponivel);
        }

        [Fact]
        public void incluir_carro_indisponivel_no_estoque_()
        {
            bool valorEsperado = true;

            var carro = new Carro()
            {
                IsDisponivel = false
            };

            carro.IncluirNoEstoque();

            Assert.Equal(valorEsperado, carro.IsDisponivel);
        }

        [Fact]
        public void incluir_carro_ja_disponivel_no_estoque_()
        {
            bool valorEsperado = true;

            var carro = new Carro()
            {
                IsDisponivel = true
            };

            carro.IncluirNoEstoque();

            Assert.Equal(valorEsperado, carro.IsDisponivel);
        }
    }
}
