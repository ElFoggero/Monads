using System;

namespace ElFoggero.Monads
{
    internal class OptionFilterMatcher<T> : IOptionMatcher<T, Option<T>>
    {
        private readonly Func<T, bool> _predicate;

        public OptionFilterMatcher(Func<T, bool> predicate)
        {
            _predicate = predicate;
        }

        public Option<T> Some(T value)
        {
            return _predicate(value) ? Option.Of(value) : Option.None<T>();
        }

        public Option<T> None()
        {
            return Option.None<T>();
        }
    }
}