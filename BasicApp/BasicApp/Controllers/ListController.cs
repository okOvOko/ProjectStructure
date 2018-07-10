using System.Collections.Generic;
using System.Threading.Tasks;
using BasicApp.Services.Abstractions;
using BasicApp.Services.Command;
using BasicApp.Services.DTOs;
using BasicApp.Services.Handlers;
using BasicApp.Services.Implementation;
using BasicApp.Services.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BasicApp.Controllers
{
    [Produces("application/json")]
    [Route("api/List")]
    public class ListController : Controller
    {
        private readonly IQueryProcessor queryProcessor;
        private readonly ICommandProcessor commandProcessor;

        public ListController(IQueryProcessor queryProcessor, ICommandProcessor commandProcessor)
        {
            this.queryProcessor = queryProcessor;
            this.commandProcessor = commandProcessor;
        }

        [HttpGet]
        public async Task<ICollection<List>> GetAllLists()
        {
            return await queryProcessor.ProcessAsync(new GetListsQuery());
        }

        [HttpPost]
        public async Task<int> CreateList([FromBody] AddListCommand command)
        {
            return await commandProcessor.ProcessAsync(command);
        }

        [HttpDelete]
        public async Task<bool> DeleteList([FromBody] DeleteListCommand command)
        {
            return await commandProcessor.ProcessAsync(command);
        }
    }
}