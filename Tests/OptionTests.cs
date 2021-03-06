﻿using FluentAssertions;
using FluentAssertions.Monads;
using ElFoggero.Monads;
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

        [Fact]
        public void Option_None_GetValueOrDefault_Calls_Factory_Function()
        {
            var option = Option.None<int>();

            var value = option.GetValueOrDefault(() => 1337);

            value.Should().Be(1337);
        }

        [Fact]
        public void Option_Some_GetValueOrDefault_Returns_Value_And_Doesnt_Call_Factory_Function()
        {
            var option = Option.Of(1337);

            var value = option.GetValueOrDefault(() =>
            {
                Assert.False(true);
                return 0;
            });

            value.Should().Be(1337);
        }

        [Fact]
        public void Option_None_GetValueOrDefault_Returns_Default_Value()
        {
            var option = Option.None<int>();

            var value = option.GetValueOrDefault();

            value.Should().Be(default(int));
        }

        [Fact]
        public void Option_Some_GetValueOrDefault_Returns_Value()
        {
            var option = Option.Of(1337);

            var value = option.GetValueOrDefault();

            value.Should().Be(1337);
        }

        [Fact]
        public void Option_Some_Filter_Returns_Value_If_Predicate_Returns_True()
        {
            var option = Option.Of(1337);

            var result = option.Filter(i => i == 1337);

            result.Should().BeSome(1337);
        }

        [Fact]
        public void Option_Some_Filter_Returns_None_If_Predicate_Returns_False()
        {
            var option = Option.Of(1337);

            var result = option.Filter(i => i != 1337);

            result.Should().BeNone();
        }
    }
}
