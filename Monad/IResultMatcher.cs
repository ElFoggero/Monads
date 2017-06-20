using System;

namespace Monad
{
    public interface IResultMatcher<in TValue, in TError, out TResult>
    {
        TResult Success(TValue value, Func<Exception, TError> exceptionHandler);

        TResult Error(TError error, Func<Exception, TError> exceptionHandler);
    }
}
