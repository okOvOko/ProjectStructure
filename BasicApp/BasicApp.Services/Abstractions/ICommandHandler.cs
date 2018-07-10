using System.Threading.Tasks;
using System.Windows.Input;

namespace BasicApp.Services.Abstractions
{
    public interface ICommandHandler<in TCommand, TResult> 
        where TCommand : ICommand<TResult> 
        where TResult: new()
    {
        Task<TResult> HandleAsync(TCommand command);
    }
}