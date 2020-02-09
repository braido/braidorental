using BraidoRental.Services.Faturamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Faturamento.Domain.Model
{
    public class RelatorioFaturamentoAnaliticoModel
    {
        public RelatorioFaturamentoAnaliticoModel(IList<CarroFaturamento> faturamentos)
        {
            Itens = faturamentos;
        }

        public IList<CarroFaturamento> Itens { get; protected set; }
    }
}
