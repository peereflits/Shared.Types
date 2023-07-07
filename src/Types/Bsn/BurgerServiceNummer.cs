using System;
using System.Text.RegularExpressions;

namespace Peereflits.Shared.Types.Bsn;

public readonly struct Burgerservicenummer
{
    private readonly int burgerServiceNummer;

    public Burgerservicenummer(int nummer)
    {
        this.burgerServiceNummer = nummer;
    }

    public bool IsValid => IsValidBsn();

    private bool IsValidBsn()
    {
        var min = 10000000;
        var max = 999999999;

        return burgerServiceNummer >= min 
               && burgerServiceNummer <= max 
               && IsElfProef();
    }

    private bool IsElfProef()
    {
        var bsnString = this.ToString();
        var sum = 0;

        for (var i = 0; i < 9; i++)
        {
            int digit = int.Parse(bsnString[i].ToString());
            int multiplier = 9 - i;
            int sign = i == 8 ? -1 : 1;

            sum += digit * multiplier * sign;
        }

        return sum % 11 == 0;
    }

    public void EnsureIsValid()
    {
        if (IsValid) return;
        throw new InvalidBsnException(this);
    }

    public static implicit operator int(Burgerservicenummer bsn) => bsn.burgerServiceNummer;

    public static implicit operator Burgerservicenummer(int bsn) => new Burgerservicenummer(bsn);

    public static Burgerservicenummer Parse(string bsn)
    {
        bsn = Regex.Replace(bsn, "[ .-]", "");
            
        int.TryParse(bsn, out int number);
        return new Burgerservicenummer(number);
    }

    public override bool Equals(object obj)
    {
        if(obj == null)
        {
            return false;
        }

        if(obj.GetType() != typeof(Burgerservicenummer) && obj.GetType() != typeof(int))
        {
            return false;
        }

        Burgerservicenummer other = obj is Burgerservicenummer bsn ? bsn : new Burgerservicenummer(Convert.ToInt32(obj));
            
        return Equals(other);
    }

    public bool Equals(Burgerservicenummer other) => burgerServiceNummer == other.burgerServiceNummer;

    public override string ToString() => burgerServiceNummer.ToString("D9");

    public override int GetHashCode() => burgerServiceNummer;
}