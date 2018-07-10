

using System.Threading.Tasks;
using BasicApp.DataAccess.Model;

namespace BasicApp.Services.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        protected readonly ToDoDbContext context;

        public UnitOfWork(ToDoDbContext context)
        {
            this.context = context;
        }

        public IRepository<TEntity> Set<TEntity>() where TEntity : Entity
        {
            return new Repository<TEntity>(context);
        }

        public int SaveChages()
        {
            return context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}