using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Base;
using Domain.Contract;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected IDbContext _db;
        protected readonly DbSet<T> _dbSet;

        protected GenericRepository(IDbContext context)
        {
            _db = context;
            _dbSet = context.Set<T>();
        }

        public T Find(object id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Edit(T entity)
        {
            _db.SetModified(entity);
        }

        public void AddRange(List<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void DeleteRange(List<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public IEnumerable<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int page = 1, int size = int.MaxValue)
        {
            return orderBy(_dbSet).Skip((page - 1) * size).Take(size).AsEnumerable();
        }

        public int Count(Expression<Func<T, bool>> predicate = null)
        {
            return predicate is null ? _dbSet.Count() : _dbSet.Where(predicate).Count();
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public T FindFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsEnumerable();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> filter = null, string includeProperties = "",
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            var query = _dbSet.AsQueryable();

            if (filter != null) query = query.Where(filter);

            query = includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return orderBy != null ? orderBy(query) : query;
        }
    }
}