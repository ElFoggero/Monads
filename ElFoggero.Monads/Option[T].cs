namespace ElFoggero.Monads
{
    /// <summary>
    /// A monad that wraps a single value or no value. <see cref="Option{T}"/> serves as a replacement for <code>null</code>
    /// </summary>
    /// <typeparam name="T">The type of the wrapped value</typeparam>
    public abstract class Option<T>
    {
        /// <summary>
        /// Applies <paramref name="matcher"/> to the <see cref="Option{T}"/> to calculate a value.
        /// </summary>
        /// <typeparam name="U">The type of the result</typeparam>
        /// <param name="matcher">The matcher to apply</param>
        /// <returns>The result of the calculation</returns>
        public abstract U Apply<U>(IOptionMatcher<T, U> matcher);
    }
}
