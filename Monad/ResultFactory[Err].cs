using System;

namespace Monad
{
    internal class ResultFactory<Err> : IResultFactory<Err>
    {
        private readonly Func<Exception, Err> _exceptionHandler;

        public ResultFactory(Func<Exception, Err> exceptionHandler)
        {
            _exceptionHandler = exceptionHandler;
        }

        public Result<A, Err> Success<A>(A value)
        {
            return new Success<A, Err>(value, _exceptionHandler);
        }

        public Result<A, Err> Error<A>(Err error)
        {
            return new Error<A, Err>(error, _exceptionHandler);
        }
    }
}
