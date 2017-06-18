namespace Monad
{
    public interface IResultMatcher<in TValue, in TError, out TResult>
    {
        TResult Success(TValue value);

        TResult Error(TError error);
    }
}
