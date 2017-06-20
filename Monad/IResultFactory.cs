namespace Monad
{
    public interface IResultFactory<Err>
    {
        Result<A, Err> Success<A>(A value);

        Result<A, Err> Error<A>(Err error);
    }
}
