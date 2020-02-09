using BraidoRental.Services.Faturamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BraidoRental.Services.Faturamento.Domain.Model
{
   public class RelatorioFaturamentoCarroModel
    {
        public IList<FaturamentoCarroModel> Itens { get; set; }

        public RelatorioFaturamentoCarroModel(IList<CarroFaturamento> faturamentos)
        {
            var porCarro = faturamentos.GroupBy(x => x.CarroLocacao).Select(
                x => new FaturamentoCarroModel()
                {
                    Carro = x.Key,
                    ValorFaturado = x.Sum(y => y.ValorTotalLocacao)
                });

            Itens = porCarro.ToList();
        }
    }
}
