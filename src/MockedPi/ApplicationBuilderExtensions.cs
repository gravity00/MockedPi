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
        /// <param name="config"></param>
        /// <returns></returns>
        public static IApplicationBuilder MapMock(this IApplicationBuilder builder, Action<MockRequestBuilder> config)
        {
            ParamAssert.NotNull(builder, nameof(builder));
            ParamAssert.NotNull(config, nameof(config));

            var mockBuilder = new MockRequestBuilder();
            config(mockBuilder);

            return builder;
        }
    }
}
