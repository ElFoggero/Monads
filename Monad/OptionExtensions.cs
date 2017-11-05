using System;

namespace Monad
{
    public static class OptionExtensions
    {
        public static Option<U> Bind<T, U>(this Option<T> option, Func<T, Option<U>> selector)
        {
            var bindMatcher = new OptionBindMatcher<T, U>(selector);
            return option.Apply(bindMatcher);
        }

        public static Option<U> Map<T, U>(this Option<T> option, Func<T, U> selector)
        {
            var mapMatcher = new OptionMapMatcher<T, U>(selector);
            return option.Apply(mapMatcher);
        }

        public static T GetValueOrDefault<T>(this Option<T> option, Func<T> defaultValueFactory)
        {
            var getValueOrDefaultMatcher = new OptionGetValueOrDefaultMatcher<T>(defaultValueFactory);
            return option.Apply(getValueOrDefaultMatcher);
        }

        public static T GetValueOrDefault<T>(this Option<T> option)
        {
            return option.GetValueOrDefault(() => default(T));
        }
    }
}