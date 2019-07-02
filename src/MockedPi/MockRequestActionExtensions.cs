using System;
using System.Threading.Tasks;

namespace MockedPi
{
    /// <summary>
    /// Extensions for <see cref="MockRequestAction"/> instances.
    /// </summary>
    public static class MockRequestActionExtensions
    {
        /// <summary>
        /// Sets the response status code
        /// </summary>
        /// <param name="action"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static MockRequestAction ApplyStatusCode(this MockRequestAction action, int statusCode)
        {
            ParamAssert.NotNull(action, nameof(action));

            return action.Apply(ctx =>
            {
                ctx.Response.StatusCode = statusCode;
                return Task.CompletedTask;
            });
        }
    }
}
