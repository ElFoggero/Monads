namespace Monad
{
    public abstract class Result<TValue, TError>
    {
        public abstract TResult Apply<TResult>(IResultMatcher<TValue, TError, TResult> matcher);
    }
}
