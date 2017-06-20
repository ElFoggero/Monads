using System;

namespace Monad
{
    public static class ResultExtensions
    {
        public static Result<B, Error> Bind<A, Error, B>(this Result<A, Error> self, Func<A, Result<B, Error>> selector)
        {
            var matcher = new BindMatcher<A, Error, B>(selector);
            return self.Apply(matcher);
        }
    }
}
