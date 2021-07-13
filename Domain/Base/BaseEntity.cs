using System;

namespace Domain.Base
{
    public abstract class BaseEntity
    {
        public bool IsDeleted { get; protected set; }
        public DateTime CreatedAt { get; init; }

        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }
    }

    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; init; }
    }
}