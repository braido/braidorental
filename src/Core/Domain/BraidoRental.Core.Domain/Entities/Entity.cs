using BraidoRental.Core.Domain.Contract.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BraidoRental.Core.Domain.Entities
{
    public abstract class Entity<TId> : IEntity<TId> where TId : struct, IEquatable<TId>
    {
        int? _requestedHashCode;
        TId _Id;

        public virtual TId Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        public bool IsTransient()
        {
            return this.Id.Equals(default(TId));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();

        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !(left == right);
        }
    }

    public abstract class Entity : Entity<int>, IEntity
    {
    }
}
