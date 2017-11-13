namespace ElFoggero.Monads
{
    internal sealed class Some<T> : Option<T>
    {
        public Some(T value)
        {
            _value = value;
        }

        private readonly T _value;

        public override U Apply<U>(IOptionMatcher<T, U> matcher)
        {
            return matcher.Some(_value);
        }
    }
}