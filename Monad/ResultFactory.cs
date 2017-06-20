using System;

namespace Monad
{

    public static class ResultFactory
    {
        public static readonly IResultFactory<Exception> Default = new ResultFactory<Exception>(ex => ex);
    }
}
