using crud.Context;
using crud.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace crud.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        ApplicationDBContext _ApplicationDBContext;
        public Repository(ApplicationDBContext applicationDBContext)
        {
            this._ApplicationDBContext = applicationDBContext;
        }
        public void Create(T entity)
        {
            this._ApplicationDBContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this._ApplicationDBContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return this._ApplicationDBContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._ApplicationDBContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            this._ApplicationDBContext.Set<T>().Update(entity);
        }
    }
}
