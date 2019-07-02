using System;

namespace MockedPi
{
    internal static class ParamAssert
    {
        public static void NotNull<T>(T value, string paramName) where T : class
        {
            if (value == null) throw new ArgumentNullException(paramName);
        }
    }
}