using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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

        /// <summary>
        /// Writes the content as a response using <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static MockRequestAction ApplyContent(this MockRequestAction action, string content)
        {
            ParamAssert.NotNull(action, nameof(action));
            ParamAssert.NotNull(content, nameof(content));

            return action.Apply(async ctx => await ctx.Response.WriteAsync(content, ctx.RequestAborted));
        }

        /// <summary>
        /// Writes the content as a response using the given encoding.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="content"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static MockRequestAction ApplyContent(this MockRequestAction action, string content, Encoding encoding)
        {
            ParamAssert.NotNull(action, nameof(action));
            ParamAssert.NotNull(content, nameof(content));
            ParamAssert.NotNull(encoding, nameof(encoding));

            return action.Apply(async ctx => await ctx.Response.WriteAsync(content, encoding, ctx.RequestAborted));
        }
    }
}
