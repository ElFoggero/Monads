﻿namespace Monad
{
    public sealed class Some<T> : Option<T>
    {

        public Some(T value)
        {
            Value = value;
        }

        public T Value { get; }

        public override U Apply<U>(IOptionMatcher<T, U> matcher)
        {
            return matcher.Match(this);
        }
    }
}