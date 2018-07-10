using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BasicApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }

    public class CustomComparer: IComparer<int>
    {
      public int Compare(int x, int y) 
      {
        return Math.Sign(Math.Sin(x) - Math.Sin(y));
      }
    }

    public static class EnumerableExtension 
    {
      public static IOrderedEnumerable<int> CustomOrderBy(this IEnumerable<int> enumerable) 
      {
        return enumerable.OrderBy(i => i, new CustomComparer());
      }
    }
}
