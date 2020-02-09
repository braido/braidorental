using BraidoRental.Core.Domain.Contract.Repository;
using BraidoRental.Services.Estoque.Domain.Contracts.Application;
using BraidoRental.Services.Estoque.Domain.Contracts.Repositories;
using BraidoRental.Services.Estoque.Domain.Entities;
using BraidoRental.Services.Locadora.Domain.Contracts.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Application.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly ICarroRepository _carroRepository;

        public EstoqueService(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public Carro EfetuarDevolucao(Carro carro)
        {
            carro.IncluirNoEstoque();
            return _carroRepository.Update(carro);
        }

        public Carro EfetuarRetirada(Carro carro)
        {
            carro.RetirarDoEstoque();
            return _carroRepository.Update(carro);
        }

        public IList<Carro> ListarCarros()
        {
            return _carroRepository.GetAll();
        }

        public IList<Carro> ListarCarrosDisponiveis()
        {
            return _carroRepository.ListarDisponiveis();
        }

        public Carro ObterCarro(int id)
        {
            return _carroRepository.FindById(id);
        }

        public Carro SalvarCarro(Carro carro)
        {
            try
            {
                carro = _carroRepository.InsertOrUpdate(carro);

                _carroRepository.UnitOfWork.SaveChanges();

                return carro;
            }
            catch (Exception ex)
            {
                _carroRepository.UnitOfWork.UndoChanges();

                throw ex;
            }
        }
    }
}
