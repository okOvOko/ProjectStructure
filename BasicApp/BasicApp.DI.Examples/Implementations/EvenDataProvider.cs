using System;
using System.Collections.Generic;
using System.Linq;
using BasicApp.DI.Exemples.Interfaces;

namespace BasicApp.DI.Exemples.Implementations
{
    public class EvenDataProvider: IDataProvider
    {
        private static readonly Random Rand = new Random();

        public IEnumerable<int> GetData()
        {
            return Enumerable.Repeat(1, 20).Select(_ => Rand.Next() % 20).Where(i => i%2 == 0);
        }
    }
}