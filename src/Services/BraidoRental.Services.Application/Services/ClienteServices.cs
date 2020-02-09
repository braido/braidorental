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
    public class ClienteServices : IClienteService
    {
        private readonly IRepository<Cliente> _repository;

        public ClienteServices(IRepository<Cliente> repository)
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

        public Cliente Salvar(Cliente Cliente)
        {
            try
            {
                Cliente = _repository.InsertOrUpdate(Cliente);

                _repository.UnitOfWork.SaveChanges();

                return Cliente;
            }
            catch(Exception ex)
            {
                _repository.UnitOfWork.UndoChanges();

                throw ex;
            }            
        }
    }
}
