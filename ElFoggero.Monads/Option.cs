using System;

namespace ElFoggero.Monads
{
    /// <summary>
    ///     Contains factory and extension methods for <see cref="Option{T}" />
    /// </summary>
    public static class Option
    {
        /// <summary>
        ///     Wraps <paramref name="value" /> in an <see cref="Option{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of the wrapped value</typeparam>
        /// <param name="value">The value to wrap</param>
        /// <returns><see cref="Some{T}" /> if <paramref name="value" /> is not null or a value type, else <see cref="None{T}" />.</returns>
        public static Option<T> Of<T>(T value)
        {
            if (value is ValueType || value != null)
                return new Some<T>(value);
            return new None<T>();
        }

        /// <summary>
        ///     Wraps a nullable <paramref name="value" /> in an <see cref="Option{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of the wrapped value</typeparam>
        /// <param name="value">The nullable value to wrap</param>
        /// <returns><see cref="Some{T}" /> if <paramref name="value" /> is not null, else <see cref="None{T}" /></returns>
        public static Option<T> Of<T>(T? value) where T : struct
        {
            if (value.HasValue)
                return new Some<T>(value.Value);
            return new None<T>();
        }

        /// <summary>
        ///     Creates a <see cref="None{T}" />
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="None{T}" /></typeparam>
        public static Option<T> None<T>()
        {
            return new None<T>();
        }

        /// <summary>
        ///     Executes a function if the <see cref="Option{T}" /> contains a value and returns the resulting
        ///     <see cref="Option{U}" />.
        /// </summary>
        /// <typeparam name="T">The type of the wrapped value</typeparam>
        /// <typeparam name="U">The type of the wrapped value of the returned <see cref="Option{T}" /></typeparam>
        /// <param name="option">The <see cref="Option{T}" /> to apply the function to</param>
        /// <param name="selector">The function to execute</param>
        /// <returns>
        ///     The result of <paramref name="selector" /> if <paramref name="option" /> contains a value, else
        ///     <see cref="None{U}" />
        /// </returns>
        public static Option<U> Bind<T, U>(this Option<T> option, Func<T, Option<U>> selector)
        {
            var bindMatcher = new OptionBindMatcher<T, U>(selector);
            return option.Apply(bindMatcher);
        }

        /// <summary>
        ///     Executes a function if the <see cref="Option{T}" /> contains a value and wraps the result in another
        ///     <see cref="Option{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of the wrapped value</typeparam>
        /// <typeparam name="U">The type of the wrapped value of the result</typeparam>
        /// <param name="option">The <see cref="Option{T}" /> to apply the function to</param>
        /// <param name="selector">The function to execute</param>
        /// <returns>The wrapped result of <paramref name="selector" /> or <see cref="None{U}" /></returns>
        public static Option<U> Map<T, U>(this Option<T> option, Func<T, U> selector)
        {
            var mapMatcher = new OptionMapMatcher<T, U>(selector);
            return option.Apply(mapMatcher);
        }

        /// <summary>
        ///     Unwraps an <see cref="Option{T}" />
        /// </summary>
        /// <typeparam name="T">The type of the wrapped value</typeparam>
        /// <param name="option">The <see cref="Option{T}" /> to unwrap</param>
        /// <param name="defaultValueFactory">
        ///     The factory function to execute if <paramref name="option" /> does not contain a
        ///     value
        /// </param>
        /// <returns>The wrapped value or the result of <paramref name="defaultValueFactory" /></returns>
        public static T GetValueOrDefault<T>(this Option<T> option, Func<T> defaultValueFactory)
        {
            var getValueOrDefaultMatcher = new OptionGetValueOrDefaultMatcher<T>(defaultValueFactory);
            return option.Apply(getValueOrDefaultMatcher);
        }

        /// <summary>
        ///     Unwraps an <see cref="Option{T}" />
        /// </summary>
        /// <typeparam name="T">The type of the wrapped value</typeparam>
        /// <param name="option">The <see cref="Option{T}" /> to unwrap</param>
        /// <returns>The wrapped value or <code>default(T)</code>/></returns>
        public static T GetValueOrDefault<T>(this Option<T> option)
        {
            return option.GetValueOrDefault(() => default(T));
        }

        /// <summary>
        ///     Applies a predicate to the wrapped value and returns <see cref="None{T}" /> if it returns <code>false</code>.
        /// </summary>
        /// <typeparam name="T">The type of the wrapped value</typeparam>
        /// <param name="option">The <see cref="Option{T}" /> to filter</param>
        /// <param name="filter">The predicate to apply</param>
        /// <returns><see cref="Some{T}" /> if filter returns <code>true</code>, else <see cref="None{T}" /></returns>
        public static Option<T> Filter<T>(this Option<T> option, Func<T, bool> filter)
        {
            var filterMatcher = new OptionFilterMatcher<T>(filter);
            return option.Apply(filterMatcher);
        }
    }
}