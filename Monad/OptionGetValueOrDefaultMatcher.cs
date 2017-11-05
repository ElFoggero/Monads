using System;

namespace ElFoggero.Monads
{
    internal class OptionGetValueOrDefaultMatcher<T> : IOptionMatcher<T, T>
    {
        private readonly Func<T> _defaultValueFactory;

        public OptionGetValueOrDefaultMatcher(Func<T> defaultValueFactory)
        {
            _defaultValueFactory = defaultValueFactory;
        }


        public T Some(T value)
        {
            return value;
        }

        public T None()
        {
            return _defaultValueFactory();
        }
    }
}