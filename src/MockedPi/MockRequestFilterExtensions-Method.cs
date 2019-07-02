using System;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace MockedPi
{
    public static partial class MockRequestFilterExtensions
    {
        /// <summary>
        /// Matches the <see cref="HttpRequest.Method"/> with the provided <see cref="HttpMethod"/>,
        /// returning true if they are the equal.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static MockRequestFilter WhenMethod(this MockRequestFilter filter, HttpMethod method)
        {
            ParamAssert.NotNull(filter, nameof(filter));
            ParamAssert.NotNull(method, nameof(method));

            return filter.When(ctx => ctx.Request.Method == method.Method);
        }

        /// <summary>
        /// Matches the <see cref="HttpRequest.Method"/> with the provided <see cref="HttpMethod"/> collection,
        /// returning true if any of them are equal.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="methods"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static MockRequestFilter WhenMethod(this MockRequestFilter filter, params HttpMethod[] methods)
        {
            ParamAssert.NotNull(filter, nameof(filter));
            ParamAssert.NotNull(methods, nameof(methods));
            ParamAssert.NotEmpty(methods, nameof(methods));

            return filter.When(ctx => methods.Any(method => ctx.Request.Method == method.Method));
        }
    }
}