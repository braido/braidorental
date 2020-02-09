using BraidoRental.Core.Domain.Contract.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Core.Domain.Contract.Repository
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }

    public interface IRepository<TEntity, TId> : IRepository
        where TEntity : class, IEntity<TId>
        where TId : struct, IEquatable<TId>
    {
        /// <summary>
        /// Insere um registro no Contexto.
        /// </summary>
        /// <param name="model">Objeto a ser inserido.</param>
        TEntity Insert(TEntity model);

        /// <summary>
        /// Busca registro pelo Id.
        /// </summary>
        /// <param name="id">Id a ser procurado.</param>
        /// <returns>O registro encontrado.</returns>
        TEntity FindById(TId id);

        /// <summary>
        /// Obtem todos registros.
        /// </summary>
        /// <returns>Uma lista não rasteada pelo Contexto.</returns>
        IList<TEntity> GetAll();

        /// <summary>
        /// Atualiza um registro no Contexto.
        /// </summary>
        /// <param name="model">Objeto a ser Atualizado no Contexto.</param>
        TEntity Update(TEntity model);

        /// <summary>
        /// Insere ou Atualiza um registro no Contexto.
        /// Se o Id do Objeto ainda não existir no Contexto, o mesmo é Inserido, se não será Atualizado.
        /// </summary>
        /// <param name="model">Objeto a ser Inserido ou Atualizado no Contexto.</param
        TEntity InsertOrUpdate(TEntity model);

        /// <summary>
        /// Remove um registro do Contexto.
        /// </summary>
        /// <param name="id">Id do registro a ser Removido.</param>
        void Delete(TId id);

        /// <summary>
        /// Remove um registro do Contexto.
        /// </summary>
        /// <param name="model">Objeto a ser Removido.</param>
        void Delete(TEntity model);
    }

    public interface IRepository<TEntity> : IRepository<TEntity, int>
        where TEntity : class, IEntity
    {
    }
}
