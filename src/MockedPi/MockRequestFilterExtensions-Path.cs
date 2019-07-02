using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace MockedPi
{
    public static partial class MockRequestFilterExtensions
    {
        /// <summary>
        /// Matches the <see cref="HttpRequest.Path"/> with the provided <see cref="PathString"/>,
        /// returning true if the paths are exact matches.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="other"></param>
        /// <param name="comparison"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static MockRequestFilter WhenPathEquals(this MockRequestFilter filter,
            PathString other, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            ParamAssert.NotNull(filter, nameof(filter));

            return filter.When(ctx => ctx.Request.Path.Equals(other, comparison));
        }

        /// <summary>
        /// Matches the <see cref="HttpRequest.Path"/> with the provided <see cref="PathString"/>,
        /// returning true if the beginning is the same.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="other"></param>
        /// <param name="comparison"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static MockRequestFilter WhenPathStartsWithSegments(this MockRequestFilter filter,
            PathString other, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            ParamAssert.NotNull(filter, nameof(filter));

            return filter.When(ctx => ctx.Request.Path.StartsWithSegments(other, comparison));
        }

        /// <summary>
        /// Matches the <see cref="HttpRequest.Path"/> with the provided <see cref="PathString"/>,
        /// returning true if it contains the second one.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="other"></param>
        /// <param name="comparison"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static MockRequestFilter WhenPathContains(this MockRequestFilter filter,
            PathString other, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            ParamAssert.NotNull(filter, nameof(filter));

            return filter.When(ctx => ctx.Request.Path.Value.IndexOf(other, comparison) >= 0);
        }

        /// <summary>
        /// Matches the <see cref="HttpRequest.Path"/> with the provided <see cref="Regex"/>,
        /// returning true if they are a match.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static MockRequestFilter WhenPathIsMatch(this MockRequestFilter filter, Regex other)
        {
            ParamAssert.NotNull(filter, nameof(filter));
            ParamAssert.NotNull(other, nameof(other));

            return filter.When(ctx => other.IsMatch(ctx.Request.Path));
        }
    }
}