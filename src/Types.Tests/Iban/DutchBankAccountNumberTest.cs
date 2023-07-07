using System.Linq;
using Peereflits.Shared.Types.Iban;
using Xunit;

namespace Peereflits.Shared.Types.Tests.Iban;

public class DutchBankAccountNumberTest
{
    [Fact]
    public void WhenIbanIsValid_ItShouldHaveNoValidationMessages()
    {
        var subject = new DutchBankAccountNumber("NL32 RABO 0383672988");

        Assert.False(subject.ValidationMessages.Any());
        Assert.True(subject.IsValid);
        Assert.Equal("NL", subject.CountryCode);
        Assert.Equal((byte)32, subject.CheckDigits);
        Assert.Equal("RABO", subject.BankCode);
        Assert.Equal("0383672988", subject.AccountNumber);
        Assert.Equal("NL32 RABO 0383 6729 88", subject.ToString());
    }

    [Theory]
    [InlineData("NL25 INGB 0207 6437 84")]
    [InlineData("NL16 RABO 0799 3575 61")]
    [InlineData("NL91 ABNA 0357 2959 00")]
    [InlineData("NL57 ASNB 0365 8144 90")]
    [InlineData("NL15 BUNQ 0805 9694 97")]
    [InlineData("NL60 KNAB 0807 3850 18")]
    public void WhenIbansAreValid_ItShouldHaveNoValidationMessages(string iban)
    {
        DutchBankAccountNumber subject = iban;

        Assert.False(subject.ValidationMessages.Any());
        Assert.True(subject.IsValid);
        Assert.Equal("NL", subject.CountryCode);
    }

    [Fact]
    public void WhenIbanHasInvalidCountryCode_ItShouldHaveValidationMessages()
    {
        DutchBankAccountNumber subject = "GB82 WEST 1234 5698 7654 32";

        Assert.True(subject.ValidationMessages.Any());
        Assert.False(subject.IsValid);
    }

    [Fact]
    public void WhenIbanHasInvalidBicCode_ItShouldHaveValidationMessages()
    {
        DutchBankAccountNumber subject = "NL36 AAAA 0857 9725 02";

        Assert.True(subject.ValidationMessages.Any());
        Assert.False(subject.IsValid);
    }

    [Fact]
    public void WhenIbanHasInvalidAccountNumber_ItShouldHaveValidationMessages()
    {
        DutchBankAccountNumber subject = "NL75 TRIO 0615 5728 13";

        Assert.True(subject.ValidationMessages.Any());
        Assert.False(subject.IsValid);
    }

    [Fact]
    public void WhenIbanHasNoAccountNumber_ItShouldHaveValidationMessages()
    {
        DutchBankAccountNumber subject = "NL56 TRIO 0000 0000 00";

        Assert.True(subject.ValidationMessages.Any());
        Assert.False(subject.IsValid);
    }

    [Fact]
    public void xWhenIbanHasInvalidAccountNumber_ItShouldHaveValidationMessages()
    {
        DutchBankAccountNumber subject = "NL75 TRIO 0615 5728 1A";

        Assert.True(subject.ValidationMessages.Any());
        Assert.False(subject.IsValid);
    }
}