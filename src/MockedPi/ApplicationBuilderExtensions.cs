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
        /// Maps a mock to a given filter and, if matched, executes the action.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="filterConfig"></param>
        /// <param name="actionConfig"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IApplicationBuilder MapMock(this IApplicationBuilder builder, 
            Action<MockRequestFilter> filterConfig, Action<MockRequestAction> actionConfig)
        {
            ParamAssert.NotNull(builder, nameof(builder));
            ParamAssert.NotNull(filterConfig, nameof(filterConfig));
            ParamAssert.NotNull(actionConfig, nameof(actionConfig));

            var mockBuilder = new MockRequestFilter();
            filterConfig(mockBuilder);
            var predicate = mockBuilder.BuildPredicate();

            var actionBuilder = new MockRequestAction();
            actionConfig(actionBuilder);
            var handler = actionBuilder.BuildHandler();

            return builder.MapWhen(ctx => predicate(ctx), b => b.Run(handler));
        }
    }
}
