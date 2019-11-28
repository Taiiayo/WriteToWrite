using Entities.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using Texts;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ToWriteDbContext ToWriteDbContext { get; set; }
        public RepositoryBase(ToWriteDbContext toWriteDbContext)
        {
            this.ToWriteDbContext = toWriteDbContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.ToWriteDbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.ToWriteDbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.ToWriteDbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.ToWriteDbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.ToWriteDbContext.Set<T>().Remove(entity);
        }
    }
}
