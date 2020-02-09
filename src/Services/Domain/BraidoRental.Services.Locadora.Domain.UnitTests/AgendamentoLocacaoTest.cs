using BraidoRental.Services.Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BraidoRental.Services.Locadora.Domain.UnitTests
{
  public  class AgendamentoLocacaoTest
    {
        [Fact]
        public void valor_total_agendamento()
        {
            decimal valorEsperado = 1000.00M;


            var agendamento = new Agendamento()
            {
                DataInicio = new DateTime(2020, 01, 01),
                DataFim = new DateTime(2020, 01, 10),
                CarroLocacao = new CarroLocacao()
                {
                    ValorDiario = 100.00M
                }
            };            

            Assert.Equal(valorEsperado, agendamento.CalcularValorTotal());

        }

    }
}
