using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Base;

namespace Domain.Contract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T Find(object id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void AddRange(List<T> entities);
        void DeleteRange(List<T> entities);
        IEnumerable<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int page = 1, int size = int.MaxValue);
        int Count(Expression<Func<T, bool>> predicate = null);
        bool Any(Expression<Func<T, bool>> predicate);
        T FindFirstOrDefault(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindBy(Expression<Func<T, bool>> filter = null, string includeProperties = "",
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
        );
    }
}