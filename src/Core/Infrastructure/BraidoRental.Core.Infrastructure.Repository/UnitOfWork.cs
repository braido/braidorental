using BraidoRental.Core.Domain.Contract.Entity;
using BraidoRental.Core.Domain.Contract.Repository;
using BraidoRental.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Core.Infrastructure.Repository
{    public abstract class UnitOfWork : DbContext, IUnitOfWork
    {
        private readonly IDictionary<string, IRepository> _repositories;

        public UnitOfWork(DbContextOptions options) : base(options)
        {
            _repositories = new Dictionary<string, IRepository>();
        }

        public void UndoChanges()
        {
            this.Dispose();
        }

        public virtual IRepository<TEntity> RepositoryOf<TEntity>()
         where TEntity : class, IEntity
        {
            return (IRepository<TEntity>)RepositoryOf<TEntity, int>();
        }

        public virtual IRepository<TEntity, TId> RepositoryOf<TEntity, TId>()
            where TEntity : class, IEntity<TId>
            where TId : struct, IEquatable<TId>
        {
            string key = typeof(IRepository<TEntity, TId>).ToString();

            if (!_repositories.ContainsKey(key))
            {
                var rep = new Repository<TEntity, TId>(this);

                _repositories.Add(key, rep);
            }

            return (IRepository<TEntity, TId>)_repositories[key];
        }
    }
}
