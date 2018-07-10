using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BasicApp.DataAccess.Model;

namespace BasicApp.Services.Repositories
{
    public interface IRepository
    {
        IEnumerable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null)
            where TEntity : Entity;

        void Create<TEntity>(TEntity entity, string createdBy = null)
            where TEntity : Entity;

        void Update<TEntity>(TEntity entity, string modifiedBy = null)
            where TEntity : Entity;

        void Delete<TEntity>(object id)
            where TEntity : Entity;

        void Delete<TEntity>(TEntity entity)
            where TEntity : Entity;

        void Save();

        Task SaveAsync();
    }
}