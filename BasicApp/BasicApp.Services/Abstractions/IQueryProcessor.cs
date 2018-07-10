using System.Threading.Tasks;

namespace BasicApp.Services.Abstractions
{
    public interface IQueryProcessor
    {
        Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query);
    }
}