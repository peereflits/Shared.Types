using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Peereflits.Shared.Types.Phone;

public class PhoneNumber
{
    private static readonly Regex PhoneNumberMatcher = new Regex(@"^(\+|00)(?<country>\d{1,3})\s(?<area>\d{1,4})(?<subscriber>(\s\d+)+)$", RegexOptions.Compiled | RegexOptions.ExplicitCapture);
    public const string AccessCode = "+";

    public PhoneNumber(int countryCode, int areaCode, long subscriberNumber)
    {
        CountryCode = countryCode;
        AreaCode = areaCode;
        SubscriberNumber = subscriberNumber;

        Validate();
    }

    public PhoneNumber(string number)
    {
        if(string.IsNullOrWhiteSpace(number))
        {
            Warnings.Add("Het telefoonnummer mag niet leeg zijn.");
            return;
        }

        string sanitized = Sanitize(number);

        Match match = PhoneNumberMatcher.Match(sanitized);

        if(match.Success)
        {
            CountryCode = int.Parse(match.Groups["country"].Value);
            AreaCode = int.Parse(match.Groups["area"].Value);
            SubscriberNumber = long.Parse(match.Groups["subscriber"].Value.Replace(" ", string.Empty));

            Validate();
        }
        else
        {
            Warnings.Add($"'{number}' wordt niet herkend als een valide telefoonnummer. "
                         + "Landnummer, netnummer en abonneenummer dienen gescheiden te zijn door een spatie.");
        }
    }

    protected static string Sanitize(string number) => number.Trim()
        .Replace("-", string.Empty)
        .Replace(".", string.Empty)
        .Replace("(", string.Empty)
        .Replace(")", string.Empty)
        .Replace("  ", " ")
        .Replace("  ", " ");

    public static implicit operator PhoneNumber(string number) => new PhoneNumber(number);

    protected readonly List<string> Warnings = new List<string>();

    public bool IsValid => !Warnings.Any();

    public string[] ValidationMessages => Warnings.ToArray();

    public void EnsureIsValid()
    {
        if(IsValid)
        {
            return;
        }

        throw new PhoneNumberException(ValidationMessages);
    }

    public int CountryCode { get; protected set; }
    public int AreaCode { get; protected set; }
    public long SubscriberNumber { get; protected set; }

    private void Validate()
    {
        if(!new CountryCodes().ContainsKey(CountryCode))
        {
            Warnings.Add("De landcode wordt niet herkend");
        }

        if(AreaCode < 1)
        {
            Warnings.Add("Het netnummer moet groter zijn dan nul");
        }

        if(AreaCode > 9999)
        {
            Warnings.Add("Het netnummer mag maximaal vier cijfers lang zijn");
        }

        if($"{CountryCode}{AreaCode}{SubscriberNumber}".Length > 15)
        {
            Warnings.Add("Een telefoonnummer mag niet meer dan 15 cijfers bevatten");
        }
    }

    public override string ToString() => $"{AccessCode}{CountryCode} {AreaCode} {SubscriberNumber.ToString("#### #### #### #### ####").Trim()}";
}