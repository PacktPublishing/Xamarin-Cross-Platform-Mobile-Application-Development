using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Master.Fibonacci.Core.DataSource
{
    public class FibonacciCache
    {
        // Dictionary to contain the cache. 
        private static Dictionary<int, WeakReference> _cache;

        public FibonacciCache()
        {
            _cache = new Dictionary<int, WeakReference>();
        }

        public object Parent { get; set; }

        /// <summary>
        /// Accessor to FibonacciItem references
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns>FibonacciItem if it is still alive</returns>
        public FibonacciItem this[int ordinal]
        {
            get
            {
                if (!_cache.ContainsKey(ordinal)) return null;

                if (_cache[ordinal].IsAlive)
                {
                    // Object was obtained with the weak reference.
                    FibonacciItem cachedItem = _cache[ordinal].Target as FibonacciItem;
                    return cachedItem;
                }
                else
                {
                    // Object reference is already disposed of   
                    return null;
                }
            }
            set { _cache[ordinal] = new WeakReference(value); }
        }
    }
}
