using System;

namespace Monad
{
    public sealed class Success<TValue, TError> : Result<TValue, TError>
    {
        private readonly TValue _value;

        public Success(TValue value, Func<Exception, TError> exceptionHandler) : base(exceptionHandler)
        {
            _value = value;
        }

        public override TResult Apply<TResult>(IResultMatcher<TValue, TError, TResult> matcher)
        {
            return matcher.Success(_value, ExceptionHandler);
        }
    }
}
