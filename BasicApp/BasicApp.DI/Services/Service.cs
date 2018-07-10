using BasicApp.DI.Interfaces;

namespace BasicApp.DI.Services
{
    public class Service : IService
    {
        private readonly TransientService transientService;
        private readonly ScopedService scopedService;
        private readonly SingletonService singletonService;

        public Service(TransientService transientService, ScopedService scopedService, SingletonService singletonService)
        {
            this.transientService = transientService;
            this.scopedService = scopedService;
            this.singletonService = singletonService;
        }

        public int SingletonNumber => singletonService.Number;
        public int ScopedNumber => scopedService.Number;
        public int TransientNumber => transientService.Number;
    }
}