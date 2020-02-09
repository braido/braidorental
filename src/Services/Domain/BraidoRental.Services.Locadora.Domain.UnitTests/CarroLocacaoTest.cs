using BraidoRental.Services.Estoque.Domain.Entities;
using BraidoRental.Services.Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BraidoRental.Services.Locadora.Domain.Tests
{
    public class CarroLocacaoTest
    {
        DateTime _now;

        DateTime _dataInicio;
        DateTime _dataFim;


        public CarroLocacaoTest()
        {
            _now = DateTime.Now;

            _dataInicio = _now.AddMonths(3);
            _dataFim = _now.AddMonths(5);
        }

        [Fact]
        public void data_agendamento_valida()
        {           

            var listaAgendamentos = new List<Agendamento>()
            {
                new Agendamento()
                {
                    DataInicio = _now.AddMonths(1),
                    DataFim = _now.AddMonths(2)
                },
                new Agendamento()
                {
                    DataInicio = _now.AddMonths(6),
                    DataFim = _now.AddMonths(7)
                }
            };

            var carroLocacao = new CarroLocacao()
            {
                Agendamentos = listaAgendamentos
            };

            Assert.True(carroLocacao.VerificarDisponibilidadeParaLocacao(_dataInicio, _dataFim));

        }

        [Fact]
        public void data_agendamento_invalida_1()
        {
            var listaAgendamentos = new List<Agendamento>()
            {
                new Agendamento()
                {
                    DataInicio = _now.AddMonths(4),
                    DataFim = _now.AddMonths(4).AddDays(15)
                }
            };

            var carroLocacao = new CarroLocacao()
            {
                Agendamentos = listaAgendamentos
            };


            Assert.False(carroLocacao.VerificarDisponibilidadeParaLocacao(_dataInicio, _dataFim));

        }
        [Fact]
        public void data_agendamento_invalida_2()
        {
            var listaAgendamentos = new List<Agendamento>()
            {
                new Agendamento()
                {
                    DataInicio = _now.AddMonths(1),
                    DataFim = _now.AddMonths(7)
                }
            };

            var carroLocacao = new CarroLocacao()
            {
                Agendamentos = listaAgendamentos
            };

            Assert.False(carroLocacao.VerificarDisponibilidadeParaLocacao(_dataInicio, _dataFim));
        }

        [Fact]
        public void data_agendamento_invalida_3()
        {
            var listaAgendamentos = new List<Agendamento>()
            {
                new Agendamento()
                {
                    DataInicio = _now.AddMonths(1),
                    DataFim =_now.AddMonths(4)
                }
            };

            var carroLocacao = new CarroLocacao()
            {
                Agendamentos = listaAgendamentos
            };

            Assert.False(carroLocacao.VerificarDisponibilidadeParaLocacao(_dataInicio, _dataFim));
        }

        [Fact]
        public void data_agendamento_invalida_4()
        {
            var listaAgendamentos = new List<Agendamento>()
            {
                new Agendamento()
                {
                    DataInicio = _now.AddMonths(4),
                    DataFim = _now.AddMonths(7),
                }
            };

            var carroLocacao = new CarroLocacao()
            {
                Agendamentos = listaAgendamentos
            };

            Assert.False(carroLocacao.VerificarDisponibilidadeParaLocacao(_dataInicio, _dataFim));
        }

        [Fact]
        public void carro_disponivel_para_locacao()
        {
            var carroLocacao = new CarroLocacao()
            {
                Carro = new Carro()
                {
                    IsDisponivel = true
               }
            };         

            Assert.True(carroLocacao.VerificarDisponibilidadeRetirada());
        }

        [Fact]
        public void carro_indisponivel_para_locacao()
        {
            var carroLocacao = new CarroLocacao()
            {
                Carro = new Carro()
                {
                    IsDisponivel = false
                }
            };

            Assert.False(carroLocacao.VerificarDisponibilidadeRetirada());
        }
    }
}
