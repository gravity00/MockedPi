namespace MockedPi
{
    /// <summary>
    /// Builder for request mocking
    /// </summary>
    public class MockRequestBuilder
    {
        /// <summary>
        /// Request filter
        /// </summary>
        public MockRequestFilter Filter { get; } = new MockRequestFilter();
    }
}
