using BraidoRental.Services.Locadora.Domain.Entities;
using BraidoRental.Services.Locadora.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Locadora.Domain.Contracts.Application
{
    public interface ILocacaoService
    {
        IList<CarroLocacao> ListarCarros();
        Agendamento RealizarAgendamento(AgendamentoModel model);
        void RealizarRetiradaCarro(RetiradaModel model);
        void RealizarDevolucaoaCarro(DevolucaoModel model);
        CarroLocacao ObterCarro(int id);
        Agendamento SimularAgendamento(SimulacaoAgendamentoModel model);
        CarroLocacao SalvarCarro(CarroLocacao carroLocacao);
    }
}
