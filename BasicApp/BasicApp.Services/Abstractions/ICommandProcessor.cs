using System.Threading.Tasks;

namespace BasicApp.Services.Abstractions
{
    public interface ICommandProcessor
    {
        Task<TResult> ProcessAsync<TResult>(ICommand<TResult> command);
    }
}