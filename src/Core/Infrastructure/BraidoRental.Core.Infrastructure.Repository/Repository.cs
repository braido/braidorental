using BraidoRental.Core.Domain.Contract.Entity;
using BraidoRental.Core.Domain.Contract.Repository;
using BraidoRental.Core.Infrastructure.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BraidoRental.Core.Infrastructure.Repository
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId>
           where TEntity : class, IEntity<TId>
           where TId : struct, IEquatable<TId>
    {
        #region Attributes

        #region ReadOnly

        private readonly UnitOfWork _unitOfWork;
        private readonly DbSet<TEntity> _entitySet;

        #endregion ReadOnly

        #endregion Attributes

        #region Properties

        public IUnitOfWork UnitOfWork => _unitOfWork;

        protected DbSet<TEntity> EntitySet => _entitySet;

        #endregion

        #region Constructor

        public Repository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _entitySet = _unitOfWork.Set<TEntity>();
        }

        #endregion Constructor

        #region Context

        protected DbSet<T> Set<T>() where T : class
        {
            return _unitOfWork.Set<T>();
        }

        #endregion Context

        #region Query

        /// <summary>
        /// Monta uma Query com filtro e propriedades inclusas para o Banco de Dados.
        /// </summary>
        /// <param name="selector">Seletor que filtrará os registros.</param>
        /// <param name="includeProps">Propriedades a serem incluidas na Query.</param>
        /// <returns>Uma Query para o banco de dados.</returns>
        protected IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> selector = null)
        {
            return selector == null ? _entitySet : _entitySet.Where(selector);
        }

        protected bool Exists(Expression<Func<TEntity, bool>> selector = null)
        {
            return Query(selector).Any();
        }

        #endregion Query

        #region CRUD


        /// <summary>
        /// Insere um registro no Contexto.
        /// </summary>
        /// <param name="entity">Objeto a ser inserido.</param>
        public virtual TEntity Insert(TEntity entity)
        {
            if (entity == null) { throw new ArgumentNullException(nameof(entity)); }

            if (entity.IsTransient())
            {
                return _entitySet.Add(entity).Entity;
            }
            else
            {
                return entity;
            }
        }

        /// <summary>
        /// Busca registro pelo Id.
        /// </summary>
        /// <param name="id">Id a ser procurado.</param>
        /// <returns>O registro encontrado.</returns>
        public virtual TEntity FindById(TId id)
        {
            return Query(x => x.Id.Equals(id)).FirstOrDefault();
        }

        /// <summary>
        /// Obtem todos registros.
        /// </summary>
        /// <returns>Uma lista não rasteada pelo Contexto.</returns>
        public virtual IList<TEntity> GetAll()
        {
            return _entitySet.ToNoTrackingList();
        }

        /// <summary>
        /// Atualiza um registro no Contexto.
        /// </summary>
        /// <param name="entity">Objeto a ser Atualizado no Contexto.</param>
        public virtual TEntity Update(TEntity entity)
        {
            if (entity == null) { throw new ArgumentNullException(nameof(entity)); }

            if (entity.Id.Equals(default(TId)))
            {
                string entityName = GetEntityName();
                throw new Exception($"Falha ao Atualizar registro da entidade '{entityName}'. O ID não pode ser vazio.");
            }

            bool hasValue = Exists(x => x.Id.Equals(entity.Id));

            if (!hasValue)
            {
                string entityName = GetEntityName();
                throw new Exception($"Falha ao Atualizar registro da entitdade '{entityName}'. O ID {entity.Id} não existe no banco de dados.");
            }

            return _entitySet.Update(entity).Entity;
        }

        /// <summary>
        /// Insere ou Atualiza um registro no Contexto.
        /// Se o Id do Objeto ainda não existir no Contexto, o mesmo é Inserido, se não será Atualizado.
        /// </summary>
        /// <param name="entity">Objeto a ser Inserido ou Atualizado no Contexto.</param>
        public virtual TEntity InsertOrUpdate(TEntity entity)
        {
            if (entity == null) { throw new ArgumentNullException(nameof(entity)); }

            bool isNewValue = entity.Id.Equals(default(TId)) || !Exists(x => x.Id.Equals(entity.Id));

            return isNewValue ? Insert(entity) : Update(entity);
        }

        /// <summary>
        /// Remove um registro do Contexto.
        /// </summary>
        /// <param name="id">Id do registro a ser Removido.</param>
        public virtual void Delete(TId id)
        {
            var entity = FindById(id);

            if (entity == null)
            {
                string entityName = GetEntityName();
                throw new Exception($"Falha ao Remover registro da entidade {entityName}. O ID {entity.Id} não existe no banco de dados.");
            }

            Delete(entity);
        }

        /// <summary>
        /// Remove um registro do Contexto.
        /// </summary>
        /// <param name="entity">Objeto a ser Removido.</param>
        public virtual void Delete(TEntity entity)
        {
            if (entity == null) { throw new ArgumentNullException(nameof(entity)); }

            _entitySet.Remove(entity);
        }


        #endregion CRUD

        #region Util

        private string GetEntityName()
        {
            return typeof(TEntity).Name;
        }

        #endregion Util
    }

    public class Repository<TEntity> : Repository<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity
    {
        public Repository(UnitOfWork unitOfWork) : base(unitOfWork)
        { }
    }
}
