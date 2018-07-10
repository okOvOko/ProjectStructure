using System.Threading.Tasks;
using BasicApp.DataAccess.Model;

namespace BasicApp.Services.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> Set<TEntity>() where TEntity: Entity;

        int SaveChages();

        Task<int> SaveChangesAsync();
    }
}