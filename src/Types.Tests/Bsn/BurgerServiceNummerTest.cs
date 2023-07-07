using System;
using FluentAssertions;
using Peereflits.Shared.Types.Bsn;
using Xunit;

namespace Peereflits.Shared.Types.Tests.Bsn;

public class BurgerServiceNummerTest
{
    public const int ValidBSN = 017399609;
    public const int InvalidBSN = 99999999;
    public const int InvalidLengthBSN = 1234567890;
    public const int EmptyBSN = 0;

    [Fact]
    public void WhenBSNHasInvalidLength_ItShouldBeInvalid()
    {
        Burgerservicenummer result = InvalidLengthBSN;

        result.IsValid.Should().BeFalse();
    }

    [Fact]
    public void WhenBSNIsValidlyParsed_ItShouldReturnTheBSN()
    {
        string bsnText = "017399609";
        Burgerservicenummer bsn = int.Parse(bsnText);

        var result = Burgerservicenummer.Parse(bsnText);

        result.Should().Be(bsn);
    }

    [Theory]
    [InlineData("0 1 7 3 9 9 6 0 9", 017399609)]
    [InlineData("0-1-7-3-9-9-6-0-9", 017399609)]
    [InlineData("0.1.7.3.9.9.6.0.9", 017399609)]
    public void WhenBSNHasNonDigitCharacters_TheyShouldBeRemoved(string number, int expectedResult)
    {
        Burgerservicenummer result = Burgerservicenummer.Parse(number);

        result.Should().Be(expectedResult);
    }

    [Fact]
    public void WhenBSNPassesElfProef_ItShouldBeValid()
    {
        Burgerservicenummer result = ValidBSN;

        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void WhenBSNDoesNotPassElfProef_ItShouldBeInvalid()
    {
        Burgerservicenummer result = InvalidBSN;
            
        result.IsValid.Should().BeFalse();
    }

    [Fact]
    public void WhenBSNIsEmpty_ItShouldBeInvalid()
    {
        Burgerservicenummer result = EmptyBSN;

        result.IsValid.Should().BeFalse();
    }

    [Theory]
    [InlineData(InvalidBSN)]
    [InlineData(InvalidLengthBSN)]
    [InlineData(EmptyBSN)]
    public void WhenEnsureIsValidWhileBsnIsInvalid_ItShouldThrowAnInvalidBsnException(int number)
    {
        Burgerservicenummer result = number;

        Action invalidBsnValidation = () => result.EnsureIsValid();
        invalidBsnValidation.Should().Throw<InvalidBsnException>();
    }

    [Fact]
    public void WhenEnsureIsValidWhileBsnIsValid_ItShouldNotThrowAnInvalidBsnException()
    {
        Burgerservicenummer result = ValidBSN;

        Action validBsnValidation = () => result.EnsureIsValid();
        validBsnValidation.Should().NotThrow<InvalidBsnException>();
    }
}