using System;

namespace Monad
{
    public static class Option
    {
        public static Option<T> Of<T>(T value)
        {
            
            if (value is ValueType || value != null)
            {
                return new Some<T>(value);
            }
            else
            {
                return new None<T>();
            }
        }

        public static Option<T> Of<T>(T? value) where T: struct
        {
            if (value.HasValue)
            {
                return new Some<T>(value.Value);
            }
            else
            {
                return new None<T>();
            }
        }

        public static Option<T> None<T>()
        {
            return new None<T>();
        }

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

        public static Option<T> Filter<T>(this Option<T> option, Func<T, bool> filter)
        {
            var filterMatcher = new OptionFilterMatcher<T>(filter);
            return option.Apply(filterMatcher);
        }
    }
}