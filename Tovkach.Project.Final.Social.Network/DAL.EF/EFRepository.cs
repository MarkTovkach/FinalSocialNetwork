using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Infrastructure;

namespace DAL.EF
{
    public class EfRepository<C, T> : IGenericRepository<T>
        where C : DbContext, new()
        where T : class
    {
        private readonly C _entities;

        public EfRepository(C context)
        {
            _entities = context;
        }
        public void Create(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }
        public IQueryable<T> GetAll()
        {
            IQueryable<T> set = _entities.Set<T>();
            return set;
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return _entities.Set<T>().Where(predicate);
        }

        public void Save()
        {
            _entities.SaveChanges();
        }
    }
}
