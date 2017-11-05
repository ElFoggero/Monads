﻿namespace ElFoggero.Monads
{
    public interface IOptionMatcher<in T, out U>
    {
        U Some(T value);

        U None();
    }
}