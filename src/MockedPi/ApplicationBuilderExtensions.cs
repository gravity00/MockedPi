using System;
using MockedPi;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Extension methods for <see cref="IApplicationBuilder"/> instances.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Maps a mock contition
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="filterConfig"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IApplicationBuilder MapMock(this IApplicationBuilder builder, 
            Action<MockRequestFilter> filterConfig)
        {
            ParamAssert.NotNull(builder, nameof(builder));
            ParamAssert.NotNull(filterConfig, nameof(filterConfig));

            var mockBuilder = new MockRequestFilter();
            filterConfig(mockBuilder);
            var predicate = mockBuilder.BuildPredicate();

            return builder;
        }
    }
}
