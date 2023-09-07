using System.Linq;
using System.Numerics;

namespace Peereflits.Shared.Types.Iban;

public class DutchBankAccountNumber : BankAccountNumber
{
    private readonly string[] bankCodes =
    {
        "AABN", // ABN AMRO Trading as Kendu
        "ABNA", // ABN AMRO Bank
        "FTSB", // ABN AMRO (ex FORTIS)
        "ABNC", // ABN AMRO Clearing Bank N.V.
        "ADYB", // ADYEN
        "AEGO", // AEGON BANK
        "ANDL", // ANADOLUBANK
        "ARBN", // ACHMEA BANK
        "ARSN", // ARGENTA SPAARBANK
        "ASNB", // ASN BANK (Volksbank)
        "ATBA", // AMSTERDAM TRADE BANK
        "BCDM", // BANQUE CHAABI DU MAROC
        "BCIT", // INTESA SANPAOLO
        "BICK", // BINCKBANK
        "BINK", // BINCKBANK, PROF
        "BITS", // BITSAFE PAYMENTS
        "BKCH", // BANK OF CHINA
        "BKMG", // BANK MENDES GANS
        "BLGW", // BLG WONEN
        "BMEU", // BMCE EUROSERVICES
        "BNDA", // BRAND NEW DAY BANK
        "BNGH", // BANK NEDERLANDSE GEMEENTEN
        "BNPA", // BNP PARIBAS
        "BOFA", // BANK OF AMERICA
        "BOFS", // BANK OF SCOTLAND LLOYDS BANK, AMSTERDAM
        "BOTK", // MUFG BANK
        "BUNQ", // BUNQ
        "CHAS", // JPMORGAN CHASE
        "CITC", // CITCO BANK
        "CITI", // CITIBANK INTERNATIONAL
        "COBA", // COMMERZBANK
        "DEUT", // DEUTSCHE BANK (bij alle SEPA-transacties)
        "DHBN", // DEMIR-HALK BANK
        "DLBK", // DELTA LLOYD BANK
        "DNIB", // NIBC
        "EBUR", // EBURY NETHERLANDS
        "FBHL", // CREDIT EUROPE BANK
        "FLOR", // DE NEDERLANDSCHE BANK
        "FRNX", // FRANX
        "FVLB", // VAN LANSCHOT
        "GILL", // INSINGERGILISSEN
        "HAND", // SVENSKA HANDELSBANKEN
        "HHBA", // HOF HOORNEMAN BANKIERS
        "HSBC", // HSBC BANK
        "ICBC", // MEGA INTERNATIONAL COMMERCIAL BANK
        "ICBK", // INDUSTRIAL & COMMERCIAL BANK OF CHINA
        "INGB", // ING
        "ISAE", // CACEIS BANK, Netherlands Branch
        "ISBK", // ISBANK
        "KABA", // YAPI KREDI BANK
        "KASA", // KAS BANK
        "KNAB", // KNAB
        "KOEX", // KEB HANA BANK
        "KRED", // KBC BANK
        "LOCY", // LOMBARD ODIER DARIER HENTSCH & CIE
        "LOYD", // LLOYDS TSB BANK
        "LPLN", // LEASEPLAN CORPORATION
        "MHCB", // MIZUHO BANK EUROPE
        "MOYO", // MONEYOU
        "NNBA", // NATIONALE-NEDERLANDEN BANK
        "NWAB", // NEDERLANDSE WATERSCHAPSBANK
        "PCBC", // CHINA CONSTRUCTION BANK, AMSTERDAM BRANCH
        "RABO", // RABOBANK
        "RBRB", // REGIOBANK (Volksbank)
        "SNSB", // SNS (Volksbank)
        "SOGE", // SOCIETE GENERALE
        "TRIO", // TRIODOS BANK
        "UGBI", // GARANTIBANK INTERNATIONAL
        "VOWA", // VOLKSWAGEN BANK
        "ZWLB"  // SNS (ex ZWITSERLEVENBANK) (Volksbank)
    };

    public DutchBankAccountNumber(string accountNumber) : base(accountNumber)
    {
        Validate();
    }

    public string BankCode => IsValid ? BasicBankAccountNumber.Substring(0, 4) : string.Empty;

    public string AccountNumber => IsValid ? BasicBankAccountNumber.Substring(4) : BasicBankAccountNumber;

    public static implicit operator DutchBankAccountNumber(string accountNumber) => new(accountNumber);

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