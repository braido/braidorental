using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Core.Domain.Contract.Entity
{
    public interface IEntity<TId> where TId : struct, IEquatable<TId>
    {
        TId Id { get; }

        bool IsTransient();
    }

    public interface IEntity : IEntity<int>
    {
    }
}
