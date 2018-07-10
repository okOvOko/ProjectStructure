using System;
using System.Threading;

namespace BasicApp.DI.Services
{
    public class RandomNumberService
    {
        private readonly Random rand = new Random();

        public RandomNumberService()
        {
            Number = rand.Next();
        }

        public int Number { get; }
    }
}