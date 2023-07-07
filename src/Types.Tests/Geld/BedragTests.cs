using System;
using Peereflits.Shared.Types.Geld;
using Xunit;

namespace Peereflits.Shared.Types.Tests.Geld;

public class BedragTests
{
    [Fact]
    public void WhenAssignInt_ItShouldSucceed()
    {
        Bedrag result = 1;
        Assert.Equal("€ 1,00", result.ToString());
    }

    [Fact]
    public void WhenAssignDouble_ItShouldSucceed()
    {
        Bedrag result = 0.99;
        Assert.Equal("€ 0,99", result.ToString());
    }

    [Fact]
    public void WhenAssignDecimal_ItShouldSucceed()
    {
        Bedrag result = 0.99M;
        Assert.Equal("€ 0,99", result.ToString());
    }

    [Fact]
    public void WhenCompareInt_ItShouldSucceed()
    {
        Bedrag result = 1;
        Assert.True(result.Equals(1));
    }

    [Fact]
    public void WhenCompareDouble_ItShouldSucceed()
    {
        Bedrag result = 0.99;
        Assert.True(result.Equals(.99));
    }

    [Fact]
    public void WhenCompareDecimal_ItShouldSucceed()
    {
        Bedrag result = 0.99M;
        Assert.True(result.Equals(.99M));
    }

    [Fact]
    public void WhenCompareNonNumeric_ItShouldReturnFalse()
    {
        Bedrag result = 0.99M;

        // ReSharper disable once SuspiciousTypeConversion.Global
        Assert.False(result.Equals("€ 0,99"));
    }

    [Theory]
    [InlineData(0, "€ 0,00")]
    [InlineData(0.994, "€ 0,99")]
    [InlineData(0.995, "€ 1,00")]
    [InlineData(1000, "€ 1.000,00")]
    [InlineData(-1, "€ 1,00-")]
    [InlineData(-1000, "€ 1.000,00-")]
    public void WhenToString_ItShouldRenderCorrect(decimal value, string expected)
    {
        Bedrag result = value;
        Assert.Equal(expected, result.ToString());
    }

    [Fact]
    public void WhenAdd_ItShouldSucceed()
    {
        Bedrag p1 = 0.01;
        Bedrag p2 = 0.02M;
        Bedrag expected = 0.03;
        Assert.True(expected.Equals(p1 + p2));
    }

    [Fact]
    public void WhenSubtract_ItShouldSucceed()
    {
        Bedrag p1 = 0.03;
        Bedrag p2 = 0.02M;
        Bedrag expected = 0.01;
        Assert.True(expected.Equals(p1 - p2));
    }

    [Fact]
    public void WhenMultiply_ItShouldSucceed()
    {
        Bedrag p1 = 0.3;
        Bedrag p2 = 2;
        Bedrag expected = 0.6;
        Assert.True(expected.Equals(p1 * p2));
    }

    [Fact]
    public void WhenDivide_ItShouldSucceed()
    {
        Bedrag p1 = 0.6;
        Bedrag p2 = 2;
        Bedrag expected = 0.3;
        Assert.True(expected.Equals(p1 / p2));
    }

    [Fact]
    public void WhenAdd_WithDifferentCurrency_ItShouldThrow()
    {
        var p1 = new Bedrag(0.1M, '€');
        var p2 = new Bedrag(0.1M, '$');
        Assert.Throws<ArithmeticException>(() => p1 + p2);
    }

    [Fact]
    public void WhenSubtract_WithDifferentCurrency_ItShouldThrow()
    {
        var p1 = new Bedrag(0.1M, '€');
        var p2 = new Bedrag(0.1M, '$');
        Assert.Throws<ArithmeticException>(() => p1 - p2);
    }
    [Fact]
    public void WhenMultiply_WithDifferentCurrency_ItShouldThrow()
    {
        var p1 = new Bedrag(0.1M, '€');
        var p2 = new Bedrag(0.1M, '$');
        Assert.Throws<ArithmeticException>(() => p1 * p2);
    }
    [Fact]
    public void WhenDivide_WithDifferentCurrency_ItShouldThrow()
    {
        var p1 = new Bedrag(0.1M, '€');
        var p2 = new Bedrag(0.1M, '$');
        Assert.Throws<ArithmeticException>(() => p1 / p2);
    }
}