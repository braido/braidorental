using BraidoRental.Services.Faturamento.Domain.Entities;
using BraidoRental.Services.Faturamento.Domain.Model;
using BraidoRental.Services.Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BraidoRental.Services.Faturamento.Domain.UnitTests
{
    public class RelatorioFaturamentoCarroModelTest
    {
        [Fact]
        public void lista_relatorio_por_carro()
        {
            int totalItensEsperados = 2;

            decimal valorTotalCarro1Esperaco = 1500.00M;
            decimal valorTotalCarro2Esperaco = 1200.00M;

            var carro1 = new CarroLocacao()
            {
                Id = 1
            };
            
            var carro2 = new CarroLocacao()
            {
                Id = 2
            };

            var faturamentos = new List<CarroFaturamento>()
            {
                new CarroFaturamento(carro1, null, 500.00M),
                new CarroFaturamento(carro2, null, 1000.00M),
                new CarroFaturamento(carro2, null, 200.00M),
                new CarroFaturamento(carro1, null, 100.00M),
                new CarroFaturamento(carro1, null, 900.00M)
            };

            var rel = new RelatorioFaturamentoCarroModel(faturamentos);

            Assert.Equal(totalItensEsperados, rel.Itens.Count);
            Assert.Equal(valorTotalCarro1Esperaco, rel.Itens.First(x => x.Carro.Id == 1).ValorFaturado);
            Assert.Equal(valorTotalCarro2Esperaco, rel.Itens.First(x => x.Carro.Id == 2).ValorFaturado);
        }
    }
}
