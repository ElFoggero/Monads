using FluentAssertions;
using Monad;
using NSubstitute;
using System;
using Xunit;

namespace Tests
{
    public class SuccessTests
    {
        [Fact]
        public void Apply_Passes_Value_To_Matcher()
        {
            var matcher = Substitute.For<IResultMatcher<int, Exception, int>>();
            const int value = 1337;

            var success = ResultFactory.Default.Success(value);
            success.Apply(matcher);

            matcher.Received().Success(value, Arg.Any<Func<Exception, Exception>>());
        }

        [Fact]
        public void Apply_Returns_Result_From_Matcher()
        {
            var matcher = Substitute.For<IResultMatcher<int, Exception, int>>();
            const int result = 1337;
            matcher.Success(Arg.Any<int>(), Arg.Any<Func<Exception, Exception>>()).Returns(result);

            var success = ResultFactory.Default.Success(0);

            var actualResult = success.Apply(matcher);

            actualResult.Should().Be(result);
        }
    }
}
