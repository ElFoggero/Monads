using ElFoggero.Monads;

namespace FluentAssertions.Monads
{
    public static class OptionAssertionExtension
    {
        public static OptionAssertions<T> Should<T>(this Option<T> option)
        {
            return new OptionAssertions<T>(option);
        }
    }
}