using System;

namespace Monad
{
    public abstract class Result<TValue, TError>
    {
        protected readonly Func<Exception, TError> ExceptionHandler;

        public abstract TResult Apply<TResult>(IResultMatcher<TValue, TError, TResult> matcher);

        protected Result(Func<Exception, TError> exceptionHandler)
        {
            ExceptionHandler = exceptionHandler;
        }
    }
}
