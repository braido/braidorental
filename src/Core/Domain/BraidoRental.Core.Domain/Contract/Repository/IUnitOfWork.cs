using BraidoRental.Core.Domain.Contract.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Core.Domain.Contract.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();

        void UndoChanges();
    }
}
