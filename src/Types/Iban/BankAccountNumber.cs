using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Peereflits.Shared.Types.Iban;

public class BankAccountNumber
{
    private readonly Dictionary<string, int> ibanLengths =
        new()
        {
            { "NL", 18 },
            { "DE", 22 },
            { "GB", 22 },
            { "BE", 16 }
        };

    private readonly string original;

    private readonly Regex regex = new(@"^([A-Z]{2})(\d{2})([A-Z0-9]{12,28})");

    public BankAccountNumber(string? accountNumber)
    {
        original = accountNumber ?? string.Empty;
        CountryCode = string.Empty;
        BasicBankAccountNumber = string.Empty;
        Validate();
    }

    public static implicit operator BankAccountNumber(string accountNumber) => new(accountNumber);

    protected readonly List<string> Warnings = new();

    public string CountryCode { get; protected set; }

    public byte CheckDigits { get; protected set; }

    public string BasicBankAccountNumber { get; protected set; }

    public bool IsValid => !Warnings.Any();

    public string[] ValidationMessages => Warnings.ToArray();

    public override string ToString() => IsValid
        ? $"{CountryCode}{CheckDigits:00} {BasicBankAccountNumber}"
        : original;

    private void Validate()
    {
        string account = original
            .Replace(" ", string.Empty)
            .Replace("—", string.Empty)
            .Replace(".", string.Empty)
            .Replace("-", string.Empty)
            .ToUpperInvariant();

        Match m = regex.Match(account);

        if(m.Success)
        {
            CountryCode = m.Groups[1].Value;
            CheckDigits = byte.Parse(m.Groups[2].Value);
            BasicBankAccountNumber = m.Groups[3].Value;

            ValidateCountryCode(account.Length);
            ValidateCheckDigits();
        }
        else
        {
            Warnings.Add("Het formaat van het IBAN nummer is onjuist");
        }
    }

    private void ValidateCountryCode(int accountLength)
    {
        if(ibanLengths.ContainsKey(CountryCode))
        {
            if(ibanLengths[CountryCode] != accountLength)
            {
                Warnings.Add("Het IBAN nummer heeft een onjuiste lengte");
            }
        }
        else
        {
            Warnings.Add("Het IBAN nummer bevat een niet ondersteunde landcode");
        }
    }

    private void ValidateCheckDigits()
    {
        char[] rearranged = $"{BasicBankAccountNumber}{CountryCode}{CheckDigits:00}".ToCharArray();
        var sb = new StringBuilder();

        foreach(char c in rearranged)
        {
            if(char.IsDigit(c))
            {
                sb.Append(c);
            }
            else
            {
                sb.Append(c - 55);
            }
        }

        BigInteger x = BigInteger.Parse(sb.ToString());

        if(x % 97 != 1)
        {
            Warnings.Add("De controle cijfers van het IBAN nummer zijn onjuist");
        }
    }
}