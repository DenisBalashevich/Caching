using System;

namespace CachingSolutionsSamples
{
    public class Fibonacci
    {
        private readonly ICache<int> _cache;

        public Fibonacci(ICache<int> cache)
        {
            _cache = cache;
        }

        public int FindFibonacciNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException();
            }

            if (number == 1 || number == 2)
            {
                return 1;
            }

            int fromCache = _cache.Get(number.ToString());
            if (fromCache != default(int))
            {
                return fromCache;
            }
            int result = FindFibonacciNumber(number - 1) + FindFibonacciNumber(number - 2);
            _cache.Set(number.ToString(), result);
            return result;
        }
    }

}
