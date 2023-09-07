using System;
using System.Text.RegularExpressions;

namespace Peereflits.Shared.Types.Mail;

public class Email
{
    private readonly Regex regex = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9A-Za-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9A-Za-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9A-Za-z][-0-9A-Za-z]*[0-9A-Za-z]*\.)+[A-Za-z0-9][\-A-Za-z0-9]{0,22}[A-Za-z0-9]))$");

    private readonly string email;

    public Email(string? email)
    {
        this.email = email?.Trim() ?? string.Empty;
        IsValid = regex.IsMatch(this.email);
    }

    /// <summary>
    ///     Returns <see langword="true" /> if the <see cref="Email" /> is valid. Otherwise <see langword="false" />.
    /// </summary>
    public bool IsValid { get; }

    /// <summary>
    ///     Throws an <see cref="InvalidEmailException" /> when not <see cref="IsValid"/>.
    /// </summary>
    public void EnsureIsValid()
    {
        if(IsValid) return;
        throw new InvalidEmailException(email);
    }

    public static implicit operator string(Email email) => email.ToString();

    public static implicit operator Email(string email) => new Email(email);

    public override bool Equals(object? obj)
    {
        if(obj == null)
        {
            return false;
        }

        if(obj.GetType() != typeof(Email) && obj.GetType() != typeof(string))
        {
            return false;
        }

        Email other = obj is Email mail ? mail : new Email(obj as string);
        return Equals(other);
    }

    public bool Equals(Email other) => string.Equals(email, other.email, StringComparison.OrdinalIgnoreCase);

    public override string ToString() => email;

    public override int GetHashCode() => StringComparer.OrdinalIgnoreCase.GetHashCode(email);
}