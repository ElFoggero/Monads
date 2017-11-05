using FluentAssertions.Execution;
using Monad;

namespace Tests
{
    public class SomeAsserter<T> : IOptionMatcher<T, T>
    {
        public T Some(T value)
        {
            return value;
        }

        public T None()
        {
            throw new AssertionFailedException($"Expected Some<{typeof(T).Name}> but got None<{typeof(T).Name}>");
        }
    }
}