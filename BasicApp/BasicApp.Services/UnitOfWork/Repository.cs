using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BasicApp.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace BasicApp.Services.UnitOfWork
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: Entity
    {
        protected readonly ToDoDbContext context;

        public Repository(ToDoDbContext context)
        {
            this.context = context;
        }
        
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }

        public virtual void Create(TEntity entity, string createdBy = null)
        {
            context.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity, string modifiedBy = null)
        {
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            TEntity entity = context.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            var dbSet = context.Set<TEntity>();
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
    }
}