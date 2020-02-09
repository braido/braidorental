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

        public RelatorioFaturamentoCarroModel FaturamentoPorCarro()
        {
            var faturamento =  _faturamentoRepository.Listar();

            return new RelatorioFaturamentoCarroModel(faturamento);
        }

        public RelatorioFaturamentoAnaliticoModel FaturamentoAnalitico()
        {
            var faturamento =  _faturamentoRepository.Listar();

            return new RelatorioFaturamentoAnaliticoModel(faturamento);
        }

        public RelatorioFaturamentoAnaliticoModel FaturamentoAnaliticoPorCarro(int idCarroLocacao)
        {
            var faturamento = _faturamentoRepository.ListarPorCarro(idCarroLocacao);

            return new RelatorioFaturamentoAnaliticoModel(faturamento);
        }

        public RelatorioFaturamentoAnaliticoModel FaturamentoAnaliticoPorCliente(int idCliente)
        {
            var faturamento = _faturamentoRepository.ListarPorCliente(idCliente);

            return new RelatorioFaturamentoAnaliticoModel(faturamento);
        }

        public RelatorioFaturamentoAnaliticoModel FaturamentoAnaliticoPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            var faturamento =  _faturamentoRepository.ListarPorPeriodo(dataInicio, dataFim);

            return new RelatorioFaturamentoAnaliticoModel(faturamento);
        }

        public RelatorioFaturamentoSinteticoModel FaturamentoSintetico()
        {
            var faturamento =  _faturamentoRepository.Listar();

            return new RelatorioFaturamentoSinteticoModel(faturamento);
        }

        public RelatorioFaturamentoSinteticoModel FaturamentoSinteticoPorCarro(int idCarroLocacao)
        {
            var faturamento =  _faturamentoRepository.ListarPorCarro(idCarroLocacao);

            return new RelatorioFaturamentoSinteticoModel(faturamento);
        }

        public RelatorioFaturamentoSinteticoModel FaturamentoSinteticoPorCliente(int idCliente)
        {
            var faturamento =  _faturamentoRepository.ListarPorCliente(idCliente);

            return new RelatorioFaturamentoSinteticoModel(faturamento);
        }

        public RelatorioFaturamentoSinteticoModel FaturamentoSinteticoPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            var faturamento = _faturamentoRepository.ListarPorPeriodo(dataInicio, dataFim);

            return new RelatorioFaturamentoSinteticoModel(faturamento);
        }
    }
}
