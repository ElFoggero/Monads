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
    }
}