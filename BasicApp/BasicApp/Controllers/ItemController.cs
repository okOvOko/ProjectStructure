using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicApp.Services.Abstractions;
using BasicApp.Services.Command;
using BasicApp.Services.DTOs;
using BasicApp.Services.Handlers;
using BasicApp.Services.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Item")]
    public class ItemController : Controller
    {
        private readonly IQueryProcessor queryProcessor;
        private readonly ICommandProcessor commandProcessor;

        public ItemController(IQueryProcessor queryProcessor, ICommandProcessor commandProcessor)
        {
            this.queryProcessor = queryProcessor;
            this.commandProcessor = commandProcessor;
        }

        [HttpGet]
        public async Task<ICollection<Item>> GetItem([FromQuery] int listId)
        {
            return await queryProcessor.ProcessAsync(new GetItemsFromListQuery{ ListId = listId });
        }

        [HttpPost]
        public async Task<int> AddItem([FromBody] AddItemCommand command)
        {
            return await commandProcessor.ProcessAsync(command);
        }

        [HttpDelete]
        public async Task<bool> DeleteItem([FromBody] DeleteItemCommand command)
        {
            return await commandProcessor.ProcessAsync(command);
        }
    }
}