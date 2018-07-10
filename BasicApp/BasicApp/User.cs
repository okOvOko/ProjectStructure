using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicApp
{
    public class CustomConverter : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return Math.Sign(Math.Sin(x) - Math.Sin(y));
        }
    }

    public static class EnumerableExctension
    {
        public static IOrderedEnumerable<int> CustomOrderBy(this IEnumerable<int> collection)
        {
            return collection.OrderBy(i => i, new CustomConverter());
        }
    }
}
