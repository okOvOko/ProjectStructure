using System.Collections.Generic;
using System.Linq;
using BasicApp.DI.Exemples.Interfaces;

namespace BasicApp.DI.Exemples.Implementations
{
    public class DescSorter : ISorter
    {
        public IEnumerable<int> Sort(IEnumerable<int> collection)
        {
            return collection.OrderByDescending(i => i);
        }
    }
}