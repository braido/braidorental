using BraidoRental.Core.Domain.Contract.Repository;
using BraidoRental.Services.Estoque.Domain.Contracts.Application;
using BraidoRental.Services.Estoque.Domain.Entities;
using BraidoRental.Services.Locadora.Domain.Contracts.Application;
using BraidoRental.Services.Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Services.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IRepository<Cliente> _repository;

        public ClienteService(IRepository<Cliente> repository)
        {
            _repository = repository;
        }

        public IList<Cliente> Listar()
        {
            return _repository.GetAll();
        }

        public Cliente Obter(int id)
        {
            return _repository.FindById(id);
        }

        public Cliente Salvar(Cliente cliente)
        {
            try
            {
                cliente = _repository.InsertOrUpdate(cliente);

                _repository.UnitOfWork.SaveChanges();

                return cliente;
            }
            catch(Exception ex)
            {
                _repository.UnitOfWork.UndoChanges();

                throw ex;
            }            
        }
    }
}
