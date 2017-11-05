using FluentAssertions;
using FluentAssertions.Monads;
using Monad;

namespace Tests
{
    public class OptionAssertions<T>
    {
        private readonly Option<T> _option;

        public OptionAssertions(Option<T> option)
        {
            _option = option;
        }

        public AndWhichConstraint<OptionAssertions<T>, T> BeSome(T expectedValue)
        {
            var value = _option.Apply(new SomeAsserter<T>());
            value.Should().Be(expectedValue);
            return new AndWhichConstraint<OptionAssertions<T>, T>(this, value);
        }

        public AndWhichConstraint<OptionAssertions<T>, T> BeSome()
        {
            var value = _option.Apply(new SomeAsserter<T>());
            return new AndWhichConstraint<OptionAssertions<T>, T>(this, value);
        }

        public AndConstraint<OptionAssertions<T>> BeNone()
        {
            _option.Apply(new NoneAsserter<T>());
            return new AndConstraint<OptionAssertions<T>>(this);
        }
    }
}