using System.Collections.Generic;

namespace BasicApp.DI.Exemples.Interfaces
{
    public interface IDataProvider
    {
        IEnumerable<int> GetData();
    }
}