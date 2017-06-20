using System;

namespace Monad
{
    internal class BindMatcher<A, Err, B> : IResultMatcher<A, Err, Result<B, Err>>
    {
        private readonly Func<A, Result<B, Err>> _selector;

        public BindMatcher(Func<A, Result<B, Err>> selector)
        {
            _selector = selector;
        }

        public Result<B, Err> Success(A value, Func<Exception, Err> exceptionHandler)
        {
            try
            {
                return _selector(value);
            }
            catch (Exception ex)
            {
                return new Error<B, Err>(exceptionHandler(ex), exceptionHandler);
            }
        }

        public Result<B, Err> Error(Err error, Func<Exception, Err> exceptionHandler)
        {
            return new Error<B, Err>(error, exceptionHandler);
        }
    }
}
