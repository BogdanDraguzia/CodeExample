using Moq;
using Xunit;

using ClassLibrary;
using ClassLibrary.Exceptions;
using ClassLibrary.Interfaces;

namespace TestProject
{
    public class StringTransformerTests
    {
        Mock<IDayOfWeekProvider> dayOfWeekProvider = new();

        StringTransformer Transformer;

        public StringTransformerTests()
        {
            SetupCurrentDayOfWeek(SomeWorkingDay);

            Transformer = new StringTransformer(dayOfWeekProvider.Object);
        }

        [Fact]
        public void Should_throw_if_input_is_null()
        {
            var exception = Assert.Throws<ArgumentNullException>(
                () => Transformer.Transform(null));

            Assert.Contains("Provided string cannot be null", exception.Message);
        }

        [Fact]
        public void Should_throw_on_Monday()
        {
            SetupCurrentDayOfWeek(DayOfWeek.Monday);

            Assert.Throws<MondayException>(
                () => Transformer.Transform("anyString"));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void Should_transform_short_string_on_all_weekdays_except_Monday(int dayOfWeek)
        {
            SetupCurrentDayOfWeek((DayOfWeek)dayOfWeek);

            var actual = Transformer.Transform(ShortString);

            Assert.Equal(TransformedShortString, actual);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void Should_transform_long_string_on_all_weekdays_except_Monday(int dayOfWeek)
        {
            SetupCurrentDayOfWeek((DayOfWeek)dayOfWeek);

            var actual = Transformer.Transform(LongString);

            Assert.Equal(TransformedLongString, actual);
        }

        void SetupCurrentDayOfWeek(DayOfWeek dayOfWeek)
        {
            dayOfWeekProvider
                .SetupGet(d => d.CurrentDayOfWeek)
                .Returns(dayOfWeek);
        }


        static readonly DayOfWeek SomeWorkingDay = DayOfWeek.Wednesday;

        const string ShortString = "ab";
        const string TransformedShortString = "AB";
        
        const string LongString = "abcde";
        const string TransformedLongString = "abcde";
    }
}