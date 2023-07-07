using System;
using System.Globalization;

namespace Peereflits.Shared.Types.Geld;

public readonly struct Bedrag
{
    private readonly char symbol;
    private readonly decimal value;

    public Bedrag(decimal value, char symbol = '€')
    {
        this.value = value;
        this.symbol = symbol;
    }

    public static implicit operator decimal(Bedrag bedrag) => bedrag.value;
    public static implicit operator Bedrag(decimal value) => new(value);
    public static implicit operator Bedrag(double value) => new((decimal)value);
    public static implicit operator Bedrag(int value) => new(value);

    public static Bedrag operator +(Bedrag a, Bedrag b) 
        => a.symbol == b.symbol
                    ? new Bedrag(a.value + b.value, a.symbol)
                    : throw new ArithmeticException("Alleen bedragen in dezelfde valuta kunnen bij elkaar worden opgeteld.");

    public static Bedrag operator -(Bedrag a, Bedrag b) 
        => a.symbol == b.symbol
                   ? new Bedrag(a.value - b.value, a.symbol)
                   : throw new ArithmeticException("Alleen bedragen in dezelfde valuta kunnen bij elkaar worden afgetrokken.");

    public static Bedrag operator *(Bedrag a, Bedrag b) 
        => a.symbol == b.symbol
                   ? new Bedrag(a.value * b.value, a.symbol)
                   : throw new ArithmeticException("Alleen bedragen in dezelfde valuta kunnen met elkaar worden vermenigvuldigd.");

    public static Bedrag operator /(Bedrag a, Bedrag b)
    {
        if(b.value == decimal.Zero)
        {
            throw new DivideByZeroException();
        }

        return a.symbol == b.symbol
                       ? new Bedrag(a.value / b.value, a.symbol)
                       : throw new ArithmeticException("Alleen bedragen in dezelfde valuta kunnen met elkaar worden gedeeld.");
    }

    /// <inheritdoc />
    public override bool Equals(object obj)
    {
        if(obj == null)
        {
            return false;
        }

        if(obj is not Bedrag && obj is not decimal && obj is not double && obj is not int)
        {
            return false;
        }

        Bedrag other = new((decimal)obj);
        return Equals(other);
    }

    /// <summary>
    ///     Returns whether the current instance equals the <paramref name="other" />.
    /// </summary>
    /// <param name="other">The other instance to compare.</param>
    /// <returns>a <see cref="bool" />.</returns>
    public bool Equals(Bedrag other) => value.Equals(other.value);

    /// <inheritdoc />
    public override int GetHashCode() => value.GetHashCode();

    /// <summary>
    ///     Returns the amount as a currency string.
    /// </summary>
    /// <returns>a <see cref="string" />.</returns>
    public override string ToString()
    {
        const int symbolSpaceNumber = 2;
        const int symbolSpaceNumberMinus = 11;
        var formatInfo = new NumberFormatInfo
                         {
                             CurrencySymbol = symbol.ToString(),
                             CurrencyDecimalDigits = 2,
                             CurrencyDecimalSeparator = ",",
                             CurrencyGroupSeparator = ".",
                             CurrencyGroupSizes = new[] { 3 },
                             CurrencyPositivePattern = symbolSpaceNumber,
                             CurrencyNegativePattern = symbolSpaceNumberMinus
                         };

        return value.ToString("C", formatInfo);
    }
}