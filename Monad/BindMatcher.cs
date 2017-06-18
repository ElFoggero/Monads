using System;

namespace Monad
{
    internal class BindMatcher<A, Error, B> : IResultMatcher<A, Error, Result<B, Error>>
    {
        private readonly Func<A, Result<B, Error>> _selector;

        public BindMatcher(Func<A, Result<B, Error>> selector)
        {
            _selector = selector;
        }

        public Result<B, Error> Success(A value)
        {
            return _selector(value);
        }

        Result<B, Error> IResultMatcher<A, Error, Result<B, Error>>.Error(Error error)
        {
            return new Error<B, Error>(error);
        }
    }
}
