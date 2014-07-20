using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ShoppingCart.Utils
{
    /// <remarks>
    /// http://blogs.msdn.com/b/pfxteam/archive/2011/01/15/10116210.aspx?utm_source=feedburner&utm_medium=twitter&utm_campaign=Feed%3A+SiteHome+(Microsoft+%7C+Blog+%7C+MSDN)
    /// </remarks>
    public class AsyncLazy<T> : Lazy<Task<T>>
    {
        public AsyncLazy(Func<T> valueFactory) :
            base(() => Task.Factory.StartNew(valueFactory)) { }

        public AsyncLazy(Func<Task<T>> taskFactory) :
            base(() => Task.Factory.StartNew(() => taskFactory()).Unwrap()) { }


        public TaskAwaiter<T> GetAwaiter() { return base.Value.GetAwaiter(); }

    }
}