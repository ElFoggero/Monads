﻿namespace ElFoggero.Monads
{
    public abstract class Option<T>
    {
        public abstract U Apply<U>(IOptionMatcher<T, U> matcher);
    }
}