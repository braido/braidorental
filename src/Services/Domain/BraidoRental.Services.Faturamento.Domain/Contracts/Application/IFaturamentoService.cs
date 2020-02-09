using BraidoRental.Services.Faturamento.Domain.Entities;
using BraidoRental.Services.Faturamento.Domain.Model;
using BraidoRental.Services.Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BraidoRental.Services.Faturamento.Domain.Contracts.Application
{
    public interface IFaturamentoService
    {
        CarroFaturamento Faturar(CarroLocacao carroLocacao, Cliente cliente, decimal valor);

        RelatorioFaturamentoCarroModel FaturamentoPorCarro();

        RelatorioFaturamentoAnaliticoModel FaturamentoAnalitico();

        RelatorioFaturamentoAnaliticoModel FaturamentoAnaliticoPorCarro(int idCarroLocacao);

        RelatorioFaturamentoAnaliticoModel FaturamentoAnaliticoPorCliente(int idCliente);

        RelatorioFaturamentoAnaliticoModel FaturamentoAnaliticoPorPeriodo(DateTime dataInicio, DateTime dataFim);

        RelatorioFaturamentoSinteticoModel FaturamentoSintetico();

        RelatorioFaturamentoSinteticoModel FaturamentoSinteticoPorCarro(int idCarroLocacao);

        RelatorioFaturamentoSinteticoModel FaturamentoSinteticoPorCliente(int idCliente);

        RelatorioFaturamentoSinteticoModel FaturamentoSinteticoPorPeriodo(DateTime dataInicio, DateTime dataFim);
    }
}
