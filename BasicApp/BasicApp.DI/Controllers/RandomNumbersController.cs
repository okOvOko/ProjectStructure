using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicApp.DI.Interfaces;
using BasicApp.DI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BasicApp.DI.Controllers
{
    [Route("api/[controller]")]
    public class RandomNumbersController : Controller
    {
        private readonly SingletonService singletonService;
        private readonly ScopedService scopedService;
        private readonly TransientService transientService;
        private readonly IService service;

        public RandomNumbersController(SingletonService singletonService, ScopedService scopedService, TransientService transientService, IService service)
        {
            this.singletonService = singletonService;
            this.scopedService = scopedService;
            this.transientService = transientService;
            this.service = service;
        }

        // GET api/values
        [HttpGet]
        public object Get()
        {
            return new
            {
                FromController = new { Singleton = singletonService.Number, Scoped = scopedService.Number, Transient = transientService.Number },
                FromService = new { Singleton = service.SingletonNumber, Scoped = service.ScopedNumber, Transient = service.TransientNumber }
            };
        }
    }
}
