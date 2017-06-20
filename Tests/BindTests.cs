using Monad;
using System;
using Xunit;

namespace Tests
{
    public class BindTests
    {
        [Fact]
        public void When_Given_A_Success_It_Returns_Selector_Result()
        {
            var expectedResult = ResultFactory.Default.Success(1337);
            var success = ResultFactory.Default.Success(23);

            var actualResult = success.Bind(i => expectedResult);

            Assert.Same(expectedResult, actualResult);
        }

        [Fact]
        public void When_Given_An_Error_It_Does_Not_Call_The_Selector()
        {
            var error = ResultFactory.Default.Error<int>(new Exception());

            Func<int, Result<int, Exception>> selector = i =>
            {
                Assert.True(false);
                return null;
            };
            
            var result = error.Bind(selector);

            Assert.IsType<Error<int, Exception>>(error);
        }
    }
}
