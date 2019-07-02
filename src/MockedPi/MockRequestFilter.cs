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
        private static readonly Func<HttpContext, bool> NoActionFilter = ctx => true;

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
        
        internal Func<HttpContext, bool> BuildPredicate()
        {
            if (_predicates.Count == 0)
                return NoActionFilter;

            var predicates = _predicates.ToArray();
            return ctx =>
            {
                foreach (var predicate in predicates)
                    if (!predicate(ctx))
                        return false;

                return true;
            };
        }
    }
}