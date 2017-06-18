namespace Monad
{
    public sealed class Error<TValue, TError> : Result<TValue, TError>
    {
        private readonly TError _error;

        public Error(TError error)
        {
            _error = error;
        }

        public override TResult Apply<TResult>(IResultMatcher<TValue, TError, TResult> matcher)
        {
            return matcher.Error(_error);
        }
    }
}
