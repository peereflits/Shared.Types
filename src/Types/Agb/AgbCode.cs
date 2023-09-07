using System;
using System.Linq;

namespace Peereflits.Shared.Types.Agb;

/// <summary>
/// A domain type for a Dutch AGB code.
/// <see href="https://www.agbcode.nl"/>
/// </summary>
public class AgbCode
{
    internal const int MinValue = 01000000;
    internal const int MaxValue = 99999999;

    private readonly int value;

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="value">The numeric value that represent the code.</param>
    public AgbCode(int value)
    {
        this.value = value;

        if(value is >= MinValue and <= MaxValue)
        {
            Discipline = GetDiscipline(value);
            SequenceNumber = GetNumber(value);
            IsValid = Discipline != Discipline.NotSet;
        }
        else
        {
            Discipline = Discipline.NotSet;
            SequenceNumber = value;
            IsValid = false;
        }
    }

    private static Discipline GetDiscipline(int value)
    {
        var discipline = value.ToString();

        int result = discipline.Length == 7
            ? int.Parse(discipline.Substring(0, 1))
            : int.Parse(discipline.Substring(0, 2));

        return Enum.IsDefined(typeof(Discipline), result)
            ? (Discipline)result
            : Discipline.NotSet;
    }

    private static int GetNumber(int value)
    {
        var discipline = value.ToString();

        return discipline.Length == 7
            ? int.Parse(discipline.Substring(1))
            : int.Parse(discipline.Substring(2));
    }

    public static implicit operator int(AgbCode agbCode) => agbCode.value;

    public static implicit operator AgbCode(int agbCode) => new AgbCode(agbCode);

    /// <summary>
    ///     Returns <see langword="true" /> if the <see cref="AgbCode" /> is valid. Otherwise <see langword="false" />.
    /// </summary>
    public bool IsValid { get; }

    /// <summary>
    ///     Returns the <see cref="Agb.Discipline" /> of the <see cref="AgbCode" />.
    /// </summary>
    public Discipline Discipline { get; }

    /// <summary>
    ///     Returns sequence number of the <see cref="AgbCode" />.
    /// </summary>
    public int SequenceNumber { get; }

    /// <summary>
    /// Vertelt of de <see cref="AgbCode"/> een instelling is.
    /// </summary>
    public bool IsInstelling => new [] { 06, 19, 22, 30, 33, 35, 40, 41, 42, 43, 45, 46, 47, 48, 53, 54, 60, 61, 65, 66, 70, 72, 73, 75, 78, 79 }
        .Contains((int)Discipline);

    /// <summary>
    /// Vertelt of de <see cref="AgbCode"/> een praktijk is.
    /// </summary>
    public bool IsPraktijk => new [] { 01, 03, 04, 05, 07, 24, 37, 88, 90, 91, 94, 96 }
        .Contains((int)Discipline);

    /// <summary>
    ///     Throws an <see cref="InvalidAgbException" /> when not <see cref="IsValid"/>.
    /// </summary>
    public void EnsureIsValid()
    {
        if(IsValid) return;
        throw new InvalidAgbException(value);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if(obj == null)
        {
            return false;
        }

        if(obj.GetType() != typeof(AgbCode) && !(obj is int))
        {
            return false;
        }

        AgbCode other = obj as AgbCode ?? new AgbCode((int)obj);
        return Equals(other);
    }

    /// <summary>
    /// Returns whether the current instance equals the <paramref name="other"/>.
    /// </summary>
    /// <param name="other">The other instance to compare.</param>
    /// <returns>a <see cref="Boolean"/>.</returns>
    public bool Equals(AgbCode other) => value.Equals(other.value);
        
    /// <inheritdoc />
    public override int GetHashCode() => value;

    /// <summary>
    /// Returns the <see cref="AgbCode"/> as an eight digit string.
    /// </summary>
    /// <returns>a <see cref="String"/>.</returns>
    public override string ToString() => value.ToString("00000000");
}