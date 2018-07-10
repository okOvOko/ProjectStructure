using BasicApp.Services.Abstractions;
using BasicApp.Services.Handlers;

namespace BasicApp.Services.Implementation
{
    public class ToDoCommandProcessor : Processor, ICommandProcessor
    {
        public ToDoCommandProcessor(ICommandHandlerFactory handlerFactory)
        {
            RegisterHandlers(handlerFactory);
        }
    }
}