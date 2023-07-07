namespace Peereflits.Shared.Types.Phone;

public class DutchPhoneNumber : PhoneNumber
{
    private const int DutchCountryCode = 31;
    private const int PhoneNumberLength = 10;
    public const int CellPhoneAreaCode = 6;

    public DutchPhoneNumber(int areaCode, long subscriberNumber)
        : base(DutchCountryCode, areaCode, subscriberNumber)
    {
        Validate();
    }

    public DutchPhoneNumber(string number) : base(IsDutch(number) ? Prepare(number) : number)
    {
        Validate();
    }

    private static bool IsDutch(string number)
    {
        if(string.IsNullOrWhiteSpace(number))
        {
            return false;
        }

        string sanitized = Sanitize(number).Replace(" ", string.Empty);;
        if(sanitized.StartsWith("+31")|| sanitized.StartsWith("0031"))
        {
            return true;
        }

        return sanitized.StartsWith("0") && sanitized.Length == PhoneNumberLength && long.TryParse(sanitized, out long _);
    }

    private static string Prepare(string number)
    {
        string sanitized = Sanitize(number).Replace(" ", string.Empty);

        if(sanitized.StartsWith("0031"))
        {
            sanitized = $"+31{sanitized.Substring(4)}";
        }

        if(sanitized.StartsWith("0"))
        {
            sanitized = $"+31{sanitized.Substring(1)}";
        }

        var area = GetAreaCode(sanitized);
        var subscriber = GetSubscriberNumber(sanitized, area);
            
        return $"{AccessCode}{DutchCountryCode} {area} {subscriber}";
    }

    private static int GetAreaCode(string sanitized)
    {
        int start = "+31".Length;
        int code = int.Parse(sanitized.Substring(start, 1));

        if(code == CellPhoneAreaCode)
        {
            return code;
        }

        code = int.Parse(sanitized.Substring(start, 3));

        return new DutchAreaCodes().ContainsKey(code) 
            ? code 
            : int.Parse(sanitized.Substring(start, 2));
    }

    private static long GetSubscriberNumber(string sanitized, int areaCode)
    {
        int start = "+31".Length + areaCode.ToString().Length;
        return long.Parse(sanitized.Substring(start));
    }

    private void Validate()
    {
        if(CountryCode != DutchCountryCode)
        {
            Warnings.Add($"De landcode is onjuist. Deze moet {DutchCountryCode} zijn.");
        }

        int code = AreaCode == CellPhoneAreaCode
            ? int.Parse($"{CellPhoneAreaCode}{SubscriberNumber.ToString()[0]}")
            : AreaCode;

        if(!new DutchAreaCodes().ContainsKey(code))
        {
            string message = AreaCode == CellPhoneAreaCode
                ? "Het mobiele nummer is onjuist."
                : "Het netnummer bestaat niet.";

            Warnings.Add(message);
        }

        if($"0{AreaCode}{SubscriberNumber}".Length != PhoneNumberLength)
        {
            Warnings.Add("Het telefoonnummer bevat een onjuist aantal cijfers.");
        }
    }

    public static implicit operator DutchPhoneNumber(string number) => new DutchPhoneNumber(number);

    public string ToString(string format)
    {
        switch(format?.ToLowerInvariant() ?? string.Empty)
        {
            case "l":
            case "local":
            case "s":
            case "short": return $"0{AreaCode} - {SubscriberNumber.ToString("#### ####").Trim()}";
            default: return base.ToString();
        }
    }
}