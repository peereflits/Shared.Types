using Peereflits.Shared.Types.Bsn;
using Xunit;

namespace Peereflits.Shared.Types.Tests.Bsn;

public class BurgerServiceNummerTest
{
    private const int ValidBsn = 017399609;
    private const int InvalidBsn = 99999999;
    private const int InvalidLengthBsn = 1234567890;
    private const int EmptyBsn = 0;

    [Fact]
    public void WhenBSNHasInvalidLength_ItShouldBeInvalid()
    {
        Burgerservicenummer result = InvalidLengthBsn;

        Assert.False(result.IsValid);
    }

    [Fact]
    public void WhenBSNIsValidlyParsed_ItShouldReturnTheBSN()
    {
        string bsnText = "017399609";
        Burgerservicenummer actual = int.Parse(bsnText);

        Burgerservicenummer result = Burgerservicenummer.Parse(bsnText);

        Assert.Equal(result, actual);
    }

    [Theory]
    [InlineData("0 1 7 3 9 9 6 0 9", 017399609)]
    [InlineData("0-1-7-3-9-9-6-0-9", 017399609)]
    [InlineData("0.1.7.3.9.9.6.0.9", 017399609)]
    public void WhenBSNHasNonDigitCharacters_TheyShouldBeRemoved(string number, int expectedResult)
    {
        Burgerservicenummer result = Burgerservicenummer.Parse(number);

        Assert.Equal((Burgerservicenummer)expectedResult, result);
    }

    [Fact]
    public void WhenBSNPassesElfProef_ItShouldBeValid()
    {
        Burgerservicenummer result = ValidBsn;

        Assert.True(result.IsValid);
    }

    [Fact]
    public void WhenBSNDoesNotPassElfProef_ItShouldBeInvalid()
    {
        Burgerservicenummer result = InvalidBsn;
            
        Assert.False(result.IsValid);
    }

    [Fact]
    public void WhenBSNIsEmpty_ItShouldBeInvalid()
    {
        Burgerservicenummer result = EmptyBsn;

        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData(InvalidBsn)]
    [InlineData(InvalidLengthBsn)]
    [InlineData(EmptyBsn)]
    public void WhenEnsureIsValid_WhileInvalid_ItShouldThrow(int number)
    {
        Burgerservicenummer result = number;

        Assert.Throws<InvalidBsnException>(() => result.EnsureIsValid());
    }

    [Fact]
    public void WhenEnsureIsValid_WhileValid_ItShouldNotThrow()
    {
        Burgerservicenummer result = ValidBsn;
        result.EnsureIsValid();
    }
}