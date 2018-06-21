using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading;

namespace CachingSolutionsSamples
{
    [TestClass]
    public class CacheTests
    {
        [TestMethod]
        public void MemoryCache()
        {
            var categoryManager = new CategoriesManager(new CategoriesMemoryCache());

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(categoryManager.GetCategories().Count());
                Thread.Sleep(100);
            }
        }

        private readonly string _fibonacciPrefix = "fibonacci";

        [TestMethod]
        public void RedisCache()
        {
            var categoryManager = new CategoriesManager(new CategoriesRedisCache("localhost"));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(categoryManager.GetCategories().Count());
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void FibonacciMemoryCache()
        {
            var fibonacci = new Fibonacci(new MemoryCache<int>(_fibonacciPrefix));

            for (var i = 1; i < 10; i++)
            {
                Console.WriteLine(fibonacci.FindFibonacciNumber(i));
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void FibonacciRedisCache()
        {
            var fibonacci = new Fibonacci(new RedisCache<int>("localhost", _fibonacciPrefix));

            for (var i = 1; i < 10; i++)
            {
                Console.WriteLine(fibonacci.FindFibonacciNumber(i));
                Thread.Sleep(100);
            }
        }
    }
}
