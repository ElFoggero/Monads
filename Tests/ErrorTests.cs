using FluentAssertions;
using Monad;
using NSubstitute;
using Xunit;

namespace Tests
{
    public class ErrorTests
    {
        [Fact]
        public void Apply_Passes_Error_To_Matcher()
        {
            var matcher = Substitute.For<IResultMatcher<int, int, int>>();
            const int value = 400;

            var error = new Error<int, int>(value);
            error.Apply(matcher);

            matcher.Received().Error(value);
        }

        [Fact]
        public void Apply_Returns_Result_From_Matcher()
        {
            var matcher = Substitute.For<IResultMatcher<int, int, int>>();
            const int result = 1337;
            matcher.Error(Arg.Any<int>()).Returns(result);

            var error = new Error<int, int>(0);

            var actualResult = error.Apply(matcher);

            actualResult.Should().Be(result);
        }
    }
}
