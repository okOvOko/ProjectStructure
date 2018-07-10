using System.Collections.Generic;
using BasicApp.DI.Exemples.Interfaces;

namespace BasicApp.DI.Exemples.Implementations
{
    public class Service : IService
    {
        private readonly ISorter sorter;
        private readonly IDataProvider dataProvider;

        public Service(ISorter sorter, IDataProvider dataProvider)
        {
            this.sorter = sorter;
            this.dataProvider = dataProvider;
        }
        public IEnumerable<int> GetEnumeration()
        {
            return sorter.Sort(dataProvider.GetData());
        }
    }
}