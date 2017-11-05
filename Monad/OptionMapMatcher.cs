using System;

namespace Monad
{
    internal class OptionMapMatcher<T, U> : IOptionMatcher<T, Option<U>>
    {
        private readonly Func<T, U> _selector;

        public OptionMapMatcher(Func<T, U> selector)
        {
            _selector = selector;
        }

        public Option<U> Some(T value)
        {
            return Option.Of(_selector(value));
        }

        public Option<U> None()
        {
            return Option.None<U>();
        }
    }
}