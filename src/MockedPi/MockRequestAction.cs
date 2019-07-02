using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

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
                throw new InvalidOperationException("Response handler collection is empty. At least an handler should be provided.");

            var handlers = _handlers.ToArray();
            return async ctx =>
            {
                var logger = (ILogger<MockRequestAction>)
                    ctx.RequestServices.GetService(typeof(ILogger<MockRequestAction>));

                if (ctx.Response.HasStarted)
                {
                    logger.LogWarning("Request matched with a filter but response already started, no handlers will be executed");
                    return;
                }

                logger.LogDebug("Request matched with a filter, executing handlers");

                foreach (var handler in handlers)
                    await handler(ctx);
            };
        }
    }
}
