using Peereflits.Shared.Types.Mail;
using Xunit;

namespace Peereflits.Shared.Types.Tests.Mail;

public class EmailTest
{
    [Theory]
    [InlineData("name@host.nl")]
    [InlineData("name@host.co.uk")]
    [InlineData("name.subname@host.co.uk")]
    [InlineData("numbers193881@host.nl")]
    [InlineData("symbols_31@host.nl")]
    [InlineData("Firstiscapital@host.com")]
    [InlineData("MuLtIPl.EcApITaLs@hOst.Ho.Com")]
    public void WhenEmailIsValid_ItShouldBeTrue(string email)
    {
        var subject = new Email(email);
        Assert.True(subject.IsValid);
    }

    [Theory]
    [InlineData("name")]
    [InlineData("host.nl")]
    [InlineData("name@host")]
    [InlineData("name@subname@host")]
    [InlineData("Abc.example.com")]     // No `@`
    [InlineData("A@b@c@example.com")]   // multiple `@`
    [InlineData("ma...ma@jjf.co")]      // continuous multiple dots in name
    [InlineData("ma@jjf.c")]            // only 1 char in extension
    [InlineData("ma@jjf..com")]         // continuous multiple dots in domain
    [InlineData("ma@@jjf.com")]         // continuous multiple `@`
    [InlineData("@majjf.com")]          // nothing before `@`
    [InlineData("ma.@jjf.com")]         // nothing after `.`
    [InlineData("ma_@jjf.com")]         // nothing after `_`
    [InlineData("ma_@jjf")]             // no domain extension 
    [InlineData("ma_@jjf.")]            // nothing after `_` and .
    [InlineData("ma@jjf.")]             // nothing after `.`
    public void WhenEmailIsInvalid_ItShouldBeFalse(string email)
    {
        var subject = new Email(email);
        Assert.False(subject.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    [InlineData("\r\n")]
    public void WhenEmailIsEmpty_ItShouldBeFalse(string email)
    {
        var subject = new Email(email);
        Assert.False(subject.IsValid);
    }

    [Fact]
    public void WhenCreatedWithoutAddress_ItShouldReturnFalse()
    {
        var subject = new Email(null);
        Assert.False(subject.IsValid);
    }

    [Fact]
    public void WhenEnsureIsValidWhileEmailIsInvalid_ItShouldThrow()
    {
        var subject = new Email(null);
        Assert.Throws<InvalidEmailException>(() => subject.EnsureIsValid());
    }

    [Fact]
    public void WhenCreated_ItShouldBeTrimmed()
    {
        var subject = new Email(" name@host.nl ");
        Assert.Equal("name@host.nl", subject.ToString());
    }

    [Fact]
    public void WhenCompare_ItShouldCompareCaseInsensitive()
    {
        var subject = new Email("NAME@HOST.NL");
        Assert.True(subject.Equals("name@host.nl"));
    }
}