using System.Threading.Tasks;

namespace BasicApp.Services.Abstractions
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}