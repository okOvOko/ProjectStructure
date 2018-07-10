using BasicApp.DataAccess.Model;
using BasicApp.Services.Abstractions;
using BasicApp.Services.Handlers;

namespace BasicApp.Services.Implementation
{
    public class ToDoQueryProcessor : Processor, IQueryProcessor
    {
        private readonly ToDoDbContext context;
        
        public ToDoQueryProcessor(IQueryHandlerFactory handlerFactory)
        {
            this.RegisterHandlers(handlerFactory);
        }
    }
}