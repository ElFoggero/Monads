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
            const int value = 1337;
            const string expected = "OK";
            matcher.Some(value).Returns(expected);

            var some = Option.Of(value);
            var result = some.Apply(matcher);

            result.Should().Be(expected);
        }

        [Fact]
        public void None_Apply_Calls_OptionMatcher_Apply()
        {
            var matcher = Substitute.For<IOptionMatcher<int, string>>();
            var none = Option.None<int>();
            const string expected = "OK";
            matcher.None().Returns(expected);

            var result = none.Apply(matcher);

            result.Should().Be(expected);
        }

        [Fact]
        public void Some_Bind_Calls_Selector()
        {
            const int value = 1337;
            var some = Option.Of(value);

            const string expectedValue = "OK";
            var actual = some.Bind(i => Option.Of(expectedValue));

            actual.Should().BeSome(expectedValue);
        }

        [Fact]
        public void None_Bind_Does_Not_Call_Selector()
        {
            var none = Option.None<int>();

            var result = none.Bind(i =>
            {
                Assert.False(true);
                return Option.Of("Fail");
            });

            result.Should().BeNone();
        }


        [Fact]
        public void Option_Of_Returns_Some_For_Value_Type()
        {
            const int i = 1337;
            var option = Option.Of(i);


            option.Should().BeSome(i);
        }

        [Fact]
        public void Option_Of_Returns_Some_For_Non_Null_Reference_Type()
        {
            const string s = "OK";
            var option = Option.Of(s);

            option.Should().BeSome(s);
        }

        [Fact]
        public void Option_Of_Returns_None_For_Null_Reference_Type()
        {
            const string s = null;
            var option = Option.Of(s);

            option.Should().BeNone();
        }

        [Fact]
        public void Option_Of_Returns_Some_For_Non_Null_Nullables()
        {
            int? i = 1337;
            var option = Option.Of(i);

            option.Should().BeSome(i.Value);
        }

        [Fact]
        public void Option_Of_Returns_None_For_Null_Nullables()
        {
            var option = Option.Of((int?) null);

            option.Should().BeNone();
        }

        [Fact]
        public void Option_None_Returns_None()
        {
            var option = Option.None<int>();

            option.Should().BeNone();
        }

        [Fact]
        public void Option_Map_On_Some_Calls_Selector()
        {
            var option = Option.Of(3);

            var result = option.Map(i => i.ToString());

            result.Should().BeSome("3");
        }

        [Fact]
        public void Option_Map_On_None_Does_Not_Call_Selector()
        {
            var option = Option.None<int>();

            var result = option.Map(i =>
            {
                Assert.False(true);
                return i.ToString();
            });

            result.Should().BeNone();
        }
    }
}
