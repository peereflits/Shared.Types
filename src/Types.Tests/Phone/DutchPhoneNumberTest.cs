using System.Linq;
using Peereflits.Shared.Types.Phone;
using Xunit;

namespace Peereflits.Shared.Types.Tests.Phone;

public class DutchPhoneNumberTest
{
    [Theory]
    [InlineData(06, 53786115)]
    [InlineData(088, 9462273)]
    [InlineData(0224, 298741)]
    public void WhenLocalNumberIsValid_ItShouldHaveNoValidationMessages(int area, long number)
    {
        var result = new DutchPhoneNumber(area, number);

        Assert.True(result.IsValid);
        Assert.False(result.ValidationMessages.Any());
    }

    [Theory]
    [InlineData("+31653786115")]
    [InlineData("+31 653786115")]
    [InlineData("+31 6 53786115")]
    [InlineData("+31 6 53 78 61 15")]
    [InlineData("0031653786115")]
    [InlineData("0031 653786115")]
    [InlineData("0031 6 53786115")]
    [InlineData("0031 6 537 861 15")]
    public void WhenParsingValidInternationalCellNumber_ItShouldHaveNoValidationMessages(string number)
    {
        DutchPhoneNumber result = number;

        Assert.True(result.IsValid);
        Assert.False(result.ValidationMessages.Any());
        Assert.Equal(31, result.CountryCode);
        Assert.Equal(6, result.AreaCode);
        Assert.Equal(53786115, result.SubscriberNumber);
    }

    [Theory]
    [InlineData("+31889462273")]
    [InlineData("+31 889462273")]
    [InlineData("+31 88 9462273")]
    [InlineData("+31 88 946 22 73")]
    [InlineData("0031889462273")]
    [InlineData("0031 889462273")]
    [InlineData("0031 88 9462273")]
    [InlineData("0031 88 946 22 73")]
    public void WhenParsingValidInternationalNumberForCity_ItShouldHaveNoValidationMessages(string number)
    {
        DutchPhoneNumber result = number;

        Assert.True(result.IsValid);
        Assert.False(result.ValidationMessages.Any());
        Assert.Equal(31, result.CountryCode);
        Assert.Equal(88, result.AreaCode);
        Assert.Equal(9462273, result.SubscriberNumber);
    }

    [Theory]
    [InlineData("+31224298741")]
    [InlineData("+31 224298741")]
    [InlineData("+31 224 298741")]
    [InlineData("+31 224 2 987 41")]
    [InlineData("0031224298741")]
    [InlineData("0031 224298741")]
    [InlineData("0031 224 298741")]
    [InlineData("0031 224 2 987 41")]
    public void WhenParsingValidInternationalNumberForNonCity_ItShouldHaveNoValidationMessages(string number)
    {
        DutchPhoneNumber result = number;

        Assert.True(result.IsValid);
        Assert.False(result.ValidationMessages.Any());
        Assert.Equal(31, result.CountryCode);
        Assert.Equal(224, result.AreaCode);
        Assert.Equal(298741, result.SubscriberNumber);
    }

    [Theory]
    [InlineData("0653786115")]
    [InlineData("06-53786115")]
    [InlineData("06-537 861 15")]
    [InlineData("06 - 537 861 15")]
    public void WhenParsedValidLocalCellPhoneNumber_ItShouldHaveNoValidationMessages(string number)
    {
        DutchPhoneNumber result = number;

        Assert.True(result.IsValid);
        Assert.Equal(31, result.CountryCode);
        Assert.Equal(6, result.AreaCode);
        Assert.Equal(53786115, result.SubscriberNumber);
        Assert.False(result.ValidationMessages.Any());
    }

    [Theory]
    [InlineData("0889462273")]
    [InlineData("088-9462273")]
    [InlineData("088 - 9462273")]
    [InlineData("088 - 946 22 73")]
    [InlineData("088 - 9  4  6  2  2  7  3")]
    [InlineData("0 8 8 - 9  4  6  2  2  7  3")]
    public void WhenParsedValidLocalNumberArea2_ItShouldHaveNoValidationMessages(string number)
    {
        DutchPhoneNumber result = number;

        Assert.True(result.IsValid);
        Assert.Equal(31, result.CountryCode);
        Assert.Equal(88, result.AreaCode);
        Assert.Equal(9462273, result.SubscriberNumber);
        Assert.False(result.ValidationMessages.Any());
    }

    [Theory]
    [InlineData("0224298741")]
    [InlineData("0224-298741")]
    [InlineData("0224 - 298741")]
    [InlineData("0224 - 2 987 41")]
    public void WhenParsedValidLocalNumberArea3_ItShouldHaveNoValidationMessages(string number)
    {
        DutchPhoneNumber result = number;

        Assert.True(result.IsValid);
        Assert.False(result.ValidationMessages.Any());
    }

    [Fact]
    public void WhenParsedWithInvalidCountryCode_ItShouldHaveWarnings()
    {
        DutchPhoneNumber result = "+32 123 456 7890";

        Assert.True(result.ValidationMessages.Any());
    }

    [Theory]
    [InlineData(11)]
    [InlineData(60)] // Invalid cell phone numbers
    [InlineData(66)] // Invalid cell phone numbers
    [InlineData(67)] // Invalid cell phone numbers
    [InlineData(69)] // Invalid cell phone numbers
    public void WhenAreaCodeIsInvalid_ItShouldHaveWarnings(int inValidAreaCode)
    {
        var result = new DutchPhoneNumber(inValidAreaCode, 12345678);

        Assert.True(result.ValidationMessages.Any());
    }

    [Theory]
    [InlineData(611111111)]
    [InlineData(711111111)]
    [InlineData(911111111)]
    public void WhenCellPhoneNumberIsInvalid_ItShouldHaveWarnings(int invalidStartNumberOfCellPhone)
    {
        var result = new DutchPhoneNumber(1, invalidStartNumberOfCellPhone);

        Assert.True(result.ValidationMessages.Any());
    }

    [Fact]
    public void WhenPhoneNumberIsLongerThan10Digits_ItShouldHaveWarnings()
    {
        var result = new DutchPhoneNumber(10, 123456789);

        Assert.True(result.ValidationMessages.Any());
    }

    [Theory]
    [InlineData("+31 224 2 987 41", "0224 - 29 8741")]
    [InlineData("+31 88 946 22 73", "088 - 946 2273")]
    [InlineData("+31 6 537 861 15", "06 - 5378 6115")]
    public void WhenToStringLocal_ItShouldBeFormattedProperly(string number, string expected)
    {
        DutchPhoneNumber result = number;

        Assert.Equal(expected, result.ToString("l"));
        Assert.Equal(expected, result.ToString("Local"));
        Assert.Equal(expected, result.ToString("S"));
        Assert.Equal(expected, result.ToString("short"));
    }
}