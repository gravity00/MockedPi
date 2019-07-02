using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MockedPi
{
    /// <summary>
    /// Request action when a filter is matched
    /// </summary>
    public class MockRequestAction
    {
        private readonly List<Func<HttpContext, Task>> _handlers = new List<Func<HttpContext, Task>>();

        /// <summary>
        /// Adds an handler to create a response
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MockRequestAction Apply(Func<HttpContext, Task> handler)
        {
            ParamAssert.NotNull(handler, nameof(handler));

            _handlers.Add(handler);

            return this;
        }

        internal RequestDelegate BuildHandler()
        {
            if (_handlers.Count == 0)
                throw new InvalidOperationException("Response handler collection is empty");

            var handlers = _handlers.ToArray();
            return async ctx =>
            {
                foreach (var handler in handlers)
                    await handler(ctx);
            };
        }
    }
}
