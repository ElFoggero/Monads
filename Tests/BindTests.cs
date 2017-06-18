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
            var expectedResult = new Success<int, object>(1337);
            var success = new Success<int, object>(23);

            var actualResult = success.Bind(i => expectedResult);

            Assert.Same(expectedResult, actualResult);
        }

        [Fact]
        public void When_Given_An_Error_It_Does_Not_Call_The_Selector()
        {
            var error = new Error<int, object>(new object());

            Func<int, Result<int, object>> selector = i =>
            {
                Assert.True(false);
                return null;
            };
            
            var result = error.Bind(selector);

            Assert.IsType<Error<int, object>>(error);
        }
    }
}
