using System;

namespace Monad
{
    public static class OptionExtensions
    {
        public static Option<U> Bind<T, U>(this Option<T> option, Func<T, Option<U>> selector)
        {
            var bindMatcher = new BindOptionMatcher<T, U>(selector);
            return option.Apply(bindMatcher);
        }
    }
}