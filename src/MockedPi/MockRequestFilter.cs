using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace MockedPi
{
    /// <summary>
    /// Request filter
    /// </summary>
    public class MockRequestFilter
    {
        private readonly List<Func<HttpContext, bool>> _predicates = new List<Func<HttpContext, bool>>();

        /// <summary>
        /// Adds a predicate to filter a given request
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MockRequestFilter When(Func<HttpContext, bool> predicate)
        {
            ParamAssert.NotNull(predicate, nameof(predicate));
            
            _predicates.Add(predicate);

            return this;
        }

        /// <summary>
        /// Is the <see cref="HttpContext"/> a match for the current filter.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool IsMatch(HttpContext context)
        {
            ParamAssert.NotNull(context, nameof(context));
            
            foreach (var predicate in _predicates)
                if (!predicate(context))
                    return false;

            return true;
        }
    }
}