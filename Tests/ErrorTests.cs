using FluentAssertions;
using Monad;
using NSubstitute;
using System;
using Xunit;

namespace Tests
{
    public class ErrorTests
    {
        [Fact]
        public void Apply_Passes_Error_To_Matcher()
        {
            var matcher = Substitute.For<IResultMatcher<int, Exception, int>>();
            var exception = new Exception();

            var error = ResultFactory.Default.Error<int>(exception);
            error.Apply(matcher);

            matcher.Received().Error(exception, Arg.Any<Func<Exception, Exception>>());
        }

        [Fact]
        public void Apply_Returns_Result_From_Matcher()
        {
            var matcher = Substitute.For<IResultMatcher<int, Exception, int>>();
            const int result = 1337;
            matcher.Error(Arg.Any<Exception>(), Arg.Any<Func<Exception, Exception>>()).Returns(result);

            var error = ResultFactory.Default.Error<int>(new Exception());

            var actualResult = error.Apply(matcher);

            actualResult.Should().Be(result);
        }
    }
}
