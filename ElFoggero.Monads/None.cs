﻿namespace ElFoggero.Monads
{
    internal sealed class None<T> : Option<T>
    {
        public override U Apply<U>(IOptionMatcher<T, U> matcher)
        {
            return matcher.None();
        }
    }
}