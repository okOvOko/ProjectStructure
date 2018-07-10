using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasicApp.Services.Abstractions;
using BasicApp.Services.Handlers;

namespace BasicApp.Services.Implementation
{
    public abstract class Processor
    {
        private Dictionary<Type, Func<object, Task<object>>> dictionary;

        public async Task<TResult> ProcessAsync<TResult>(ICommand<TResult> command) =>
            (TResult)await dictionary[command.GetType()](command);

        public async Task<TResult> ProcessAsync<TResult>(IQuery<TResult> command) =>
            (TResult)await dictionary[command.GetType()](command);

        protected void RegisterHandlers(IHandlerFactory commandHandlerFactory) =>
            dictionary = commandHandlerFactory.GetHandlers();
    }
}