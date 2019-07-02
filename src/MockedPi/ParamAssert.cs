using System;

namespace MockedPi
{
    internal static class ParamAssert
    {
        public static void NotNull<T>(T value, string paramName) where T : class
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
        }

        public static void NotEmpty<T>(T[] values, string paramName) where T : class
        {
            if (values.Length == 0)
                throw new ArgumentException("Value cannot be an empty collection.", paramName);
        }
    }
}