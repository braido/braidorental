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
        void Faturar(CarroLocacao carroLocacao, Cliente cliente, decimal valor);

        Task<RelatorioFaturamentoCarroModel> FaturamentoPorCarro();

        Task<RelatorioFaturamentoAnaliticoModel> FaturamentoAnalitico();

        Task<RelatorioFaturamentoAnaliticoModel> FaturamentoAnaliticoPorCarro(int idCarroLocacao);

        Task<RelatorioFaturamentoAnaliticoModel> FaturamentoAnaliticoPorCliente(int idCliente);

        Task<RelatorioFaturamentoAnaliticoModel> FaturamentoAnaliticoPorPeriodo(DateTime dataInicio, DateTime dataFim);

        Task<RelatorioFaturamentoSinteticoModel> FaturamentoSintetico();

        Task<RelatorioFaturamentoSinteticoModel> FaturamentoSinteticoPorCarro(int idCarroLocacao);

        Task<RelatorioFaturamentoSinteticoModel> FaturamentoSinteticoPorCliente(int idCliente);

        Task<RelatorioFaturamentoSinteticoModel> FaturamentoSinteticoPorPeriodo(DateTime dataInicio, DateTime dataFim);
    }
}
