using FluentAssertions;
using Monad;
using NSubstitute;
using Xunit;

namespace Tests
{
    public class OptionTests
    {
        [Fact]
        public void Some_Apply_Calls_OptionMatcher_Apply()
        {
            var matcher = Substitute.For<IOptionMatcher<int, string>>();
            var some = new Some<int>(1337);
            const string expected = "OK";
            matcher.Match(some).Returns(expected);

            var result = some.Apply(matcher);

            result.Should().Be(expected);
        }

        [Fact]
        public void None_Apply_Calls_OptionMatcher_Apply()
        {
            var matcher = Substitute.For<IOptionMatcher<int, string>>();
            var none = new None<int>();
            const string expected = "OK";
            matcher.Match(none).Returns(expected);

            var result = none.Apply(matcher);

            result.Should().Be(expected);
        }

        [Fact]
        public void Some_Bind_Calls_Selector()
        {
            var some = new Some<int>(1337);
            var result = new Some<string>("OK");

            var actual = some.Bind(i =>
            {
                i.Should().Be(some.Value);
                return result;
            });

            actual.Should().BeSameAs(result);
        }

        [Fact]
        public void None_Bind_Does_Not_Call_Selector()
        {
            var none = new None<int>();

            var result = none.Bind(i =>
            {
                Assert.False(true);
                return new Some<string>("Fail");
            });

            result.Should().BeOfType<None<string>>();
        }


        [Fact]
        public void Option_Of_Returns_Some_For_Value_Type()
        {
            const int i = 1337;
            var option = Option.Of(i);

            option.Should().BeOfType<Some<int>>().Which.Value.Should().Be(i);
        }

        [Fact]
        public void Option_Of_Returns_Some_For_Non_Null_Reference_Type()
        {
            const string s = "OK";
            var option = Option.Of(s);

            option.Should().BeOfType<Some<string>>().Which.Value.Should().Be(s);
        }

        [Fact]
        public void Option_Of_Returns_None_For_Null_Reference_Type()
        {
            const string s = null;
            var option = Option.Of(s);

            option.Should().BeOfType<None<string>>();
        }

        [Fact]
        public void Option_Of_Returns_Some_For_Non_Null_Nullables()
        {
            int? i = 1337;
            var option = Option.Of(i);

            option.Should().BeOfType<Some<int>>().Which.Value.Should().Be(i);
        }

        [Fact]
        public void Option_Of_Returns_None_For_Null_Nullables()
        {
            int? i = null;
            var option = Option.Of(i);

            option.Should().BeOfType<None<int>>();
        }

        [Fact]
        public void Option_None_Returns_None()
        {
            var option = Option.None<int>();

            option.Should().BeOfType<None<int>>();
        }
    }
}
