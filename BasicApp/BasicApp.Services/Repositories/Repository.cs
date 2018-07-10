using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BasicApp.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace BasicApp.Services.Repositories
{
    public class Repository : IRepository
    {
        protected readonly ToDoDbContext context;
        
        public Repository(ToDoDbContext context)
        {
            this.context = context;
        }

        public virtual IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : Entity
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }

        public virtual void Create<TEntity>(TEntity entity, string createdBy = null)
            where TEntity : Entity
        {
            context.Set<TEntity>().Add(entity);
        }

        public virtual void Update<TEntity>(TEntity entity, string modifiedBy = null)
            where TEntity : Entity
        {
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete<TEntity>(object id)
            where TEntity : Entity
        {
            TEntity entity = context.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public virtual void Delete<TEntity>(TEntity entity)
            where TEntity : Entity
        {
            var dbSet = context.Set<TEntity>();
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }

        public virtual Task SaveAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}