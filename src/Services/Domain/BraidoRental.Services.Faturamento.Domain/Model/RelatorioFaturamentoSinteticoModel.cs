using BraidoRental.Services.Faturamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BraidoRental.Services.Faturamento.Domain.Model
{
    public class RelatorioFaturamentoSinteticoModel
    {
        public int QtdCarrosLocados { get; protected set; }

        public int QtdCliente { get; protected set; }
        
        public decimal ValorTotalFaturado { get; protected set; }

        public DateTime DataInicio { get; protected set; }

        public DateTime DataFim { get; protected set; }

        public RelatorioFaturamentoSinteticoModel(IList<CarroFaturamento> faturamentos)
        {
            QtdCarrosLocados = faturamentos.GroupBy(x => x.CarroLocacao.Id).Count();
            QtdCliente = faturamentos.GroupBy(x => x.Cliente.Id).Count();
            ValorTotalFaturado = faturamentos.Sum(x => x.ValorTotalLocacao);
            DataInicio = faturamentos.Min(x => x.Data);
            DataFim = faturamentos.Max(x => x.Data);
        }
    }
}
