using BraidoRental.Services.Faturamento.Domain.Contracts.Application;
using BraidoRental.Services.Faturamento.Domain.Contracts.Repositories;
using BraidoRental.Services.Faturamento.Domain.Entities;
using BraidoRental.Services.Faturamento.Domain.Model;
using BraidoRental.Services.Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BraidoRental.Services.Application.Services
{
    public class FaturamentoService : IFaturamentoService
    {
        private readonly IFaturamentoRepository _faturamentoRepository;
        public FaturamentoService(IFaturamentoRepository faturamentoRepository)
        {
            _faturamentoRepository = faturamentoRepository;
        }

        public CarroFaturamento Faturar(CarroLocacao carroLocacao, Cliente cliente, decimal valor)
        {
            var faturamento = new CarroFaturamento(carroLocacao, cliente, valor);

            return _faturamentoRepository.Insert(faturamento);
        }

        public async Task<RelatorioFaturamentoCarroModel> FaturamentoPorCarro()
        {
            var faturamento = await _faturamentoRepository.Listar();

            return new RelatorioFaturamentoCarroModel(faturamento);
        }

        public async Task<RelatorioFaturamentoAnaliticoModel> FaturamentoAnalitico()
        {
            var faturamento = await _faturamentoRepository.Listar();

            return new RelatorioFaturamentoAnaliticoModel(faturamento);
        }

        public async Task<RelatorioFaturamentoAnaliticoModel> FaturamentoAnaliticoPorCarro(int idCarroLocacao)
        {
            var faturamento = await _faturamentoRepository.ListarPorCarro(idCarroLocacao);

            return new RelatorioFaturamentoAnaliticoModel(faturamento);
        }

        public async Task<RelatorioFaturamentoAnaliticoModel> FaturamentoAnaliticoPorCliente(int idCliente)
        {
            var faturamento = await _faturamentoRepository.ListarPorCliente(idCliente);

            return new RelatorioFaturamentoAnaliticoModel(faturamento);
        }

        public async Task<RelatorioFaturamentoAnaliticoModel> FaturamentoAnaliticoPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            var faturamento = await _faturamentoRepository.ListarPorPeriodo(dataInicio, dataFim);

            return new RelatorioFaturamentoAnaliticoModel(faturamento);
        }

        public async Task<RelatorioFaturamentoSinteticoModel> FaturamentoSintetico()
        {
            var faturamento = await _faturamentoRepository.Listar();

            return new RelatorioFaturamentoSinteticoModel(faturamento);
        }

        public async Task<RelatorioFaturamentoSinteticoModel> FaturamentoSinteticoPorCarro(int idCarroLocacao)
        {
            var faturamento = await _faturamentoRepository.ListarPorCarro(idCarroLocacao);

            return new RelatorioFaturamentoSinteticoModel(faturamento);
        }

        public async Task<RelatorioFaturamentoSinteticoModel> FaturamentoSinteticoPorCliente(int idCliente)
        {
            var faturamento = await _faturamentoRepository.ListarPorCliente(idCliente);

            return new RelatorioFaturamentoSinteticoModel(faturamento);
        }

        public async Task<RelatorioFaturamentoSinteticoModel> FaturamentoSinteticoPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            var faturamento = await _faturamentoRepository.ListarPorPeriodo(dataInicio, dataFim);

            return new RelatorioFaturamentoSinteticoModel(faturamento);
        }
    }
}
