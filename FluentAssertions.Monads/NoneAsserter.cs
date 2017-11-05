using FluentAssertions.Execution;
using Monad;

namespace FluentAssertions.Monads
{
    public class NoneAsserter<T> : IOptionMatcher<T, T>
    {
        public T Some(T value)
        {
            throw new AssertionFailedException($"Expected None<{typeof(T).Name}> but got Some<{typeof(T).Name}>({value})");
        }

        public T None()
        {
            return default(T);
        }
        
    }
}