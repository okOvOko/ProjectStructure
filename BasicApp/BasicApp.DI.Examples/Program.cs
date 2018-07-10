using System;
using System.Linq;
using BasicApp.DI.Exemples.Implementations;
using BasicApp.DI.Exemples.Interfaces;
using SimpleInjector;

namespace BasicApp.DI.Exemples
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();

            container.Register<IDataProvider, EvenDataProvider>();
            container.Register<ISorter, AscSorter>();
            container.Register<IService, Service>();

            var dataProvider = container.GetInstance<IDataProvider>();
            var sorter = container.GetInstance<ISorter>();
            var service = container.GetInstance<IService>();

            //Console.WriteLine(sorter.Sort(dataProvider.GetData()).Aggregate("", (a,b) => a += $" {b}"));
            Console.WriteLine(service.GetEnumeration().Aggregate("", (a, b) => a += $" {b}"));
        }
    }
}
