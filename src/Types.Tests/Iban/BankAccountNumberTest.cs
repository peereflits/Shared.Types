using System.Linq;
using Peereflits.Shared.Types.Iban;
using Xunit;

namespace Peereflits.Shared.Types.Tests.Iban;

public class BankAccountNumberTest
{
    [Fact]
    public void WhenIbanIsValid_ItShouldHaveNoValidationMessages()
    {
        var subject = new BankAccountNumber("GB82 WEST 1234 5698 7654 32");

        Assert.False(subject.ValidationMessages.Any());
        Assert.True(subject.IsValid);
        Assert.Equal("GB", subject.CountryCode);
        Assert.Equal((byte)82, subject.CheckDigits);
        Assert.Equal("WEST12345698765432", subject.BasicBankAccountNumber);
    }

    [Fact]
    public void WhenIbanIsValid_ItShouldBeSanitized()
    {
        var subject = new BankAccountNumber(" GB82-WEST—1234.5698.7654 32 ");

        Assert.False(subject.ValidationMessages.Any());
        Assert.True(subject.IsValid);
        Assert.Equal("GB", subject.CountryCode);
        Assert.Equal("WEST12345698765432", subject.BasicBankAccountNumber);
        Assert.Equal((byte)82, subject.CheckDigits);
    }

    [Fact]
    public void WhenIbanHasInvalidCheckDigit_ItShouldHaveValidationMessages()
    {
        var subject = new BankAccountNumber("GB81 WEST 1234 5698 7654 32");

        Assert.True(subject.ValidationMessages.Any());
        Assert.False(subject.IsValid);
        Assert.Equal("GB", subject.CountryCode);
        Assert.Equal("WEST12345698765432", subject.BasicBankAccountNumber);
        Assert.Equal((byte)81, subject.CheckDigits);
    }

    [Theory]
    [InlineData("1B81 WEST 1234 5698 7654 32")]
    [InlineData("G181 WEST 1234 5698 7654 32")]
    [InlineData("GB8a WEST 1234 5698 7654 32")]
    [InlineData("GBa1 WEST 1234 5698 7654 32")]
    [InlineData("GB81 !EST 1234 5698 7654 32")]
    [InlineData("GB81 @EST 1234 5698 7654 32")]
    [InlineData("GB81 #EST 1234 5698 7654 32")]
    [InlineData("GB81 %EST 1234 5698 7654 32")]
    [InlineData("GB81 ^EST 1234 5698 7654 32")]
    [InlineData("GB81 &EST 1234 5698 7654 32")]
    [InlineData("GB81 *EST 1234 5698 7654 32")]
    [InlineData("GB81 (EST 1234 5698 7654 32")]
    [InlineData("GB81 )EST 1234 5698 7654 32")]
    [InlineData("GB81 +EST 1234 5698 7654 32")]
    public void WhenIbanHasInvalidFormat_ItShouldHaveValidationMessages(string account)
    {
        var subject = new BankAccountNumber(account);

        Assert.True(subject.ValidationMessages.Any());
        Assert.False(subject.IsValid);
    }

    [Fact]
    public void WhenIbanHasAnUnsupportedCountry_ItShouldHaveValidationMessages()
    {
        var subject = new BankAccountNumber("QQ81 WEST 1234 5698 7654 32");

        Assert.True(subject.ValidationMessages.Any());
        Assert.False(subject.IsValid);
    }

    [Fact]
    public void WhenIbanHasInvalidLength_ItShouldHaveValidationMessages()
    {
        var subject = new BankAccountNumber("GB81 WEST 1234 5698 7654 321");

        Assert.True(subject.ValidationMessages.Any());
        Assert.False(subject.IsValid);
    }
}