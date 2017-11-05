namespace Monad
{
    public interface IOptionMatcher<T, out U>
    {
        U Match(Some<T> some);

        U Match(None<T> none);
    }
}