using System;

namespace Monad
{
    internal sealed class OptionBindMatcher<T, U> : IOptionMatcher<T, Option<U>>
    {
        private readonly Func<T, Option<U>> _selector;

        public OptionBindMatcher(Func<T, Option<U>> selector)
        {
            _selector = selector;
        }
        public Option<U> Some(T value)
        {
            return _selector(value);
        }

        public Option<U> None()
        {
            return new None<U>();
        }
    }
}