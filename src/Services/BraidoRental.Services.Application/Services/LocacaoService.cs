using BraidoRental.Core.Domain.Contract.Repository;
using BraidoRental.Services.Estoque.Domain.Contracts.Application;
using BraidoRental.Services.Estoque.Domain.Contracts.Repositories;
using BraidoRental.Services.Estoque.Domain.Entities;
using BraidoRental.Services.Faturamento.Domain.Contracts.Application;
using BraidoRental.Services.Locadora.Domain.Contracts.Application;
using BraidoRental.Services.Locadora.Domain.Entities;
using BraidoRental.Services.Locadora.Domain.Exceptions;
using BraidoRental.Services.Locadora.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Application.Services
{
    public class LocacaoService : ILocacaoService
    {
        private readonly IRepository<Cliente> _clienteRepository;
        private readonly ICarroLocacaoRepository _carroLocacaoRepository;
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IEstoqueService _estoqueService;
        private readonly IFaturamentoService _faturamentoService;

        public LocacaoService(
            IRepository<Cliente> clienteRepository,
            ICarroLocacaoRepository carroLocacaoRepository,
            IAgendamentoRepository agendamentoRepository,
            IEstoqueService estoqueService,
            IFaturamentoService faturamentoService)
        {
            _clienteRepository = clienteRepository;
            _carroLocacaoRepository = carroLocacaoRepository;
            _agendamentoRepository = agendamentoRepository;
            _estoqueService = estoqueService;
            _faturamentoService = faturamentoService;
        }

        public Agendamento RealizarAgendamento(AgendamentoModel model)
        {
            var carroLocacao = _carroLocacaoRepository.Obter(model.IdCarro);

            if (carroLocacao.VerificarDisponibilidadeParaLocacao(model.DataInicio, model.DataFim))
            {
                var cliente = _clienteRepository.FindById(model.IdCliente);

                var agendamento = new Agendamento()
                {
                    CarroLocacao = carroLocacao,
                    Cliente = cliente,
                    DataInicio = model.DataInicio,
                    DataFim = model.DataFim
                };

                _faturamentoService.Faturar(carroLocacao, cliente, agendamento.CalcularValorTotal());

                agendamento = _agendamentoRepository.Insert(agendamento);
                _agendamentoRepository.UnitOfWork.SaveChanges();

                return agendamento;
            }
            else
            {
                throw new DataLocacaoIndisponivelException();
            }
        }

        public void RealizarRetiradaCarro(RetiradaModel model)
        {
            var agendamento = _agendamentoRepository.BuscarAgendamentoPendente(model.IdCarro, model.IdCliente);

            var clienteSemAgendamento = agendamento == null;

            if (clienteSemAgendamento)
            {
                throw new ClienteNaoPossuiLocacaoException();
            }
            else
            {
                var carroLocacao = _carroLocacaoRepository.Obter(model.IdCarro);
                var carro = _estoqueService.EfetuarRetirada(carroLocacao.Carro);

                carroLocacao.Carro = carro;
                agendamento.CarroLocacao = carroLocacao;
                agendamento.CarroComCliente = true;

                _agendamentoRepository.Update(agendamento);
                _agendamentoRepository.UnitOfWork.SaveChanges();
            }
        }

        public void RealizarDevolucaoaCarro(DevolucaoModel model)
        {
            var agendamento = _agendamentoRepository.BuscarAgendamentoEmAndamento(model.IdCarro, model.IdCliente);

            var clienteSemAgendamento = agendamento == null;

            if (clienteSemAgendamento)
            {
                throw new ClienteNaoPossuiLocacaoException();
            }
            else
            {
                var carroLocacao = _carroLocacaoRepository.Obter(model.IdCarro);
                var carro = _estoqueService.EfetuarDevolucao(carroLocacao.Carro);

                carroLocacao.Carro = carro;
                agendamento.CarroLocacao = carroLocacao;
                agendamento.CarroComCliente = false;

                _agendamentoRepository.Update(agendamento);
                _agendamentoRepository.UnitOfWork.SaveChanges();
            }
        }

        public IList<CarroLocacao> ListarCarros()
        {
            return _carroLocacaoRepository.Listar();
        }

        public CarroLocacao ObterCarro(int id)
        {
            return _carroLocacaoRepository.Obter(id);
        }

        public Agendamento SimularAgendamento(SimulacaoAgendamentoModel model)
        {
            var carroLocacao = _carroLocacaoRepository.Obter(model.IdCarro);
                       
            var agendamento = new Agendamento()
            {
                CarroLocacao = carroLocacao,
                DataInicio = model.DataInicio,
                DataFim = model.DataFim
            };

            agendamento.CalcularValorTotal();

            return agendamento;
        }

        public CarroLocacao SalvarCarro(CarroLocacao carroLocacao)
        {
            try
            {
                carroLocacao = _carroLocacaoRepository.InsertOrUpdate(carroLocacao);

                _carroLocacaoRepository.UnitOfWork.SaveChanges();

                return carroLocacao;
            }
            catch(Exception ex)
            {
                _carroLocacaoRepository.UnitOfWork.UndoChanges();

                throw ex;
            }       
        }
    }
}

