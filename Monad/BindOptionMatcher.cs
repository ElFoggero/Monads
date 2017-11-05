using System;

namespace Monad
{
    internal sealed class BindOptionMatcher<T, U> : IOptionMatcher<T, Option<U>>
    {
        private readonly Func<T, Option<U>> _selector;

        public BindOptionMatcher(Func<T, Option<U>> selector)
        {
            _selector = selector;
        }
        public Option<U> Match(Some<T> some)
        {
            return _selector(some.Value);
        }

        public Option<U> Match(None<T> none)
        {
            return new None<U>();
        }
    }
}