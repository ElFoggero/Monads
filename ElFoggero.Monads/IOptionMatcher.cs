namespace ElFoggero.Monads
{
    /// <summary>
    /// Matcher that allows access to the wrapped value of an <see cref="Option{T}"/> instance. 
    /// </summary>
    /// <typeparam name="T">The type of the wrapped value</typeparam>
    /// <typeparam name="U">The type of the result</typeparam>
    /// <remarks>
    /// This interface is the only way to determine if an instance of <see cref="Option{T}"/> is <see cref="Some{T}"/> or <see cref="None{T}"/>. 
    /// In the case of <see cref="Some{T}"/> it enables access to the wrapped value. 
    /// This interface is used together with <see cref="Option{T}.Apply{U}"/> to produce a value of type <typeparamref name="U"/>.
    /// </remarks>
    public interface IOptionMatcher<in T, out U>
    {
        /// <summary>
        /// Gets called when the <see cref="Option{T}"/> is a <see cref="Some{T}"/>
        /// </summary>
        /// <param name="value">The wrapped value</param>
        /// <returns>The result of the operation.</returns>
        U Some(T value);

        /// <summary>
        /// Gets called when the <see cref="Option{T}"/> is a <see cref="None{T}"/>
        /// </summary>
        /// <returns>The result of the operation.</returns>
        U None();
    }
}