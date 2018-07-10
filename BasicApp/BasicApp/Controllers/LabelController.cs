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
    [Route("api/Label")]
    public class LabelController : Controller
    {
        private readonly IQueryProcessor queryProcessor;
        private readonly ICommandProcessor commandProcessor;

        public LabelController(IQueryProcessor queryProcessor, ICommandProcessor commandProcessor)
        {
            this.queryProcessor = queryProcessor;
            this.commandProcessor = commandProcessor;
        }

        [HttpGet]
        public async Task<ICollection<Label>> GetLabels([FromQuery] int itemId)
        {
            return await queryProcessor.ProcessAsync(new GetLabelsFromItemQuery { ItemId = itemId });
        }

        [HttpPost]
        public async Task<int> AddLabel([FromBody] AddLabelCommand command)
        {
            return await commandProcessor.ProcessAsync(command);
        }

        [HttpDelete]
        public async Task<bool> DeleteLabel([FromBody] DeleteLabelFromItemCommand command)
        {
            return await commandProcessor.ProcessAsync(command);
        }
    }
}