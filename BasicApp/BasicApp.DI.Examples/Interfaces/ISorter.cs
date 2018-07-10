using System.Collections.Generic;

namespace BasicApp.DI.Exemples.Interfaces
{
    public interface ISorter
    {
        IEnumerable<int> Sort(IEnumerable<int> collection);
    }
}