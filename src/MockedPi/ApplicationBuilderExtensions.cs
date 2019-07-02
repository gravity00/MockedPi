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
        /// <returns></returns>
        public static IApplicationBuilder MapMock(this IApplicationBuilder builder)
        {
            ParamAssert.NotNull(builder, nameof(builder));

            return builder;
        }
    }
}
