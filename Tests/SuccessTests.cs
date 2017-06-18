using FluentAssertions;
using Monad;
using NSubstitute;
using Xunit;

namespace Tests
{
    public class SuccessTests
    {
        [Fact]
        public void Apply_Passes_Value_To_Matcher()
        {
            var matcher = Substitute.For<IResultMatcher<int, int, int>>();
            const int value = 1337;

            var success = new Success<int, int>(value);
            success.Apply(matcher);

            matcher.Received().Success(value);
        }

        [Fact]
        public void Apply_Returns_Result_From_Matcher()
        {
            var matcher = Substitute.For<IResultMatcher<int, int, int>>();
            const int result = 1337;
            matcher.Success(Arg.Any<int>()).Returns(result);

            var success = new Success<int, int>(0);

            var actualResult = success.Apply(matcher);

            actualResult.Should().Be(result);
        }
    }
}
