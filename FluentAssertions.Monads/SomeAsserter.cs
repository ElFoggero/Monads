using FluentAssertions.Execution;
using ElFoggero.Monads;

namespace FluentAssertions.Monads
{
    internal class SomeAsserter<T> : IOptionMatcher<T, T>
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