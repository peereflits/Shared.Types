using System.Linq;
using Peereflits.Shared.Types.Phone;
using Xunit;

namespace Peereflits.Shared.Types.Tests.Phone;

public class PhoneNumberTest
{
    [Theory]
    [InlineData(1, 800, 6427676)]
    [InlineData(44, 344, 8002400)]
    [InlineData(31, 20, 5001500)]
    [InlineData(32, 2, 5033113)]
    public void WhenIsValid_ItShouldHaveNoValidationMessages(int code, int area, int number)
    {
        var result = new PhoneNumber(code, area, number);

        Assert.True(result.IsValid);
        Assert.False(result.ValidationMessages.Any());
    }

    [Theory]
    [InlineData("+1 1234 1 234 567 890")]
    [InlineData("+1 1234 12 3456 7890")]
    [InlineData("+1 1234 12 34 56 78 90")]
    [InlineData("+1 1234 123 456 7890")]
    [InlineData("+1 1234 123 4567 890")]
    [InlineData("+1 1234 1234567890")]
    public void WhenParsedWhileValid_ItShouldHaveNoValidationMessages(string number)
    {
        PhoneNumber result = number;

        Assert.True(result.IsValid);
        Assert.False(result.ValidationMessages.Any());
    }

    [Theory]
    [InlineData("+1 1234 - 1 234 567 890")]
    [InlineData("+1 (1234) 12 3456 7890")]
    [InlineData("+1 1234 12.34.56.78.90")]
    [InlineData(" +1 1234 1234567890 ")]
    public void WhenParsed_ItShouldBeSanitized(string number)
    {
        PhoneNumber result = number;

        Assert.True(result.IsValid);
        Assert.False(result.ValidationMessages.Any());
    }

    [Theory]
    [InlineData("+1 1234 1 234 567 890")]
    [InlineData("+1 1234 12 3456 7890")]
    [InlineData("+1 1234 12 34 56 78 90")]
    [InlineData("+1 1234 123 456 7890")]
    [InlineData("+1 1234 123 4567 890")]
    [InlineData("+1 1234 1234567890")]
    public void WhenToString_ItShouldBeFormattedProperly(string number)
    {
        PhoneNumber result = number;

        Assert.Equal("+1 1234 12 3456 7890", result.ToString());
    }

    [Fact]
    public void WhenCountryCodeIsInvalid_ItShouldHaveWarnings()
    {
        var inValidCountryCode = 2;
        var result = new PhoneNumber(inValidCountryCode, 123, 456789);

        Assert.Equal("+2 123 45 6789", result.ToString());
        Assert.True(result.ValidationMessages.Any());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10000)]
    public void WhenAreaCodeIsInvalid_ItShouldHaveWarnings(int inValidAreaCode)
    {
        var result = new PhoneNumber(1, inValidAreaCode, 456789);

        Assert.True(result.ValidationMessages.Any());
    }

    [Fact]
    public void WhenPhoneNumberIsLongerThan15Digits_ItShouldHaveWarnings()
    {
        var result = new PhoneNumber(1, 9999, 12345678901);

        Assert.True(result.ValidationMessages.Any());
    }

    [Fact]
    public void WhenEnsureIsValidWhileNumberIsInvalid_ItShouldThrow()
    {
        var result = new PhoneNumber(2, 9999, 12345678901);

        Assert.Throws<PhoneNumberException>(() => result.EnsureIsValid());
    }

    [Fact]
    public void WhenParsed_ItShouldBeTheSameAsOriginal()
    {
        var expected = new PhoneNumber(1, 9999, 123456789);
        var actual = new PhoneNumber(expected.ToString());

        Assert.Equal(expected.CountryCode, actual.CountryCode);
        Assert.Equal(expected.AreaCode, actual.AreaCode);
        Assert.Equal(expected.SubscriberNumber, actual.SubscriberNumber);
    }

    [Theory]
    [InlineData(default(string))]
    [InlineData("")]
    [InlineData("\t")]
    [InlineData(" ")]
    [InlineData("Not a phone number")]
    public void WhenPhoneNumberIsNotANumber_ItShouldHaveWarnings(string? number)
    {
        var result = new PhoneNumber(number ?? string.Empty);

        Assert.True(result.ValidationMessages.Any());
    }
}