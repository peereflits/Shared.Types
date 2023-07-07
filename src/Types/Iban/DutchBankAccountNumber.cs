using System.Linq;
using System.Numerics;

namespace Peereflits.Shared.Types.Iban;

public class DutchBankAccountNumber : BankAccountNumber
{
    private readonly string[] bankCodes =
    {
        "ABNA", // ABN AMRO BANK
        "ASNB", // ASN BANK
        "BUNQ", // BUNQ BANK
        "FVLB", // F.VAN LANSCHOT BANKIERS
        "INGB", // ING BANK
        "KNAB", // KNAB
        "RABO", // RABOBANK
        "RBRB", // REGIOBANK
        "SNSB", // SNS BANK
        "TRIO"  // TRIODOS BANK
    };

    public DutchBankAccountNumber(string accountNumber) : base(accountNumber)
    {
        Validate();
    }

    public static implicit operator DutchBankAccountNumber(string accountNumber) => new DutchBankAccountNumber(accountNumber);

    public string BankCode => IsValid ? BasicBankAccountNumber.Substring(0, 4) : string.Empty;

    public string AccountNumber => IsValid ? BasicBankAccountNumber.Substring(4) : BasicBankAccountNumber;

    private void Validate()
    {
        if(CountryCode != "NL")
        {
            Warnings.Add("De landcode van het Nederlandse IBAN nummer is onjuist");
        }

        if(BankCode != string.Empty && !bankCodes.Contains(BankCode))
        {
            Warnings.Add("De bankcode van het IBAN nummer wordt niet herkend");
        }

        ValidateAccountNumber();
    }

    private void ValidateAccountNumber()
    {
        if(!BigInteger.TryParse(AccountNumber, out BigInteger i))
        {
            Warnings.Add("Het rekeningnummer mag alleen uit cijfers bestaan");
            return;
        }

        if(i <= 0)
        {
            Warnings.Add("Het rekeningnummer mag niet alleen uit nullen bestaan");
            return;
        }

        if(!IsElfProefBestendig())
        {
            Warnings.Add("Het rekeningnummer voldoet niet aan de elf-proef");
        }
    }

    private bool IsElfProefBestendig()
    {
        char[] nr = AccountNumber.ToCharArray();

        decimal x = int.Parse(nr[0].ToString()) * 10
                    + int.Parse(nr[1].ToString()) * 9
                    + int.Parse(nr[2].ToString()) * 8
                    + int.Parse(nr[3].ToString()) * 7
                    + int.Parse(nr[4].ToString()) * 6
                    + int.Parse(nr[5].ToString()) * 5
                    + int.Parse(nr[6].ToString()) * 4
                    + int.Parse(nr[7].ToString()) * 3
                    + int.Parse(nr[8].ToString()) * 2
                    + int.Parse(nr[9].ToString()) * 1;

        return x % 11 == 0;
    }

    public override string ToString() => IsValid
        ? $"{CountryCode}{CheckDigits:00} {BankCode} {BigInteger.Parse(AccountNumber):0000 0000 00}"
        : base.ToString();
}