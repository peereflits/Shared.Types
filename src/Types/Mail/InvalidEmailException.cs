using System;

namespace Peereflits.Shared.Types.Mail;

public class InvalidEmailException : Exception
{
    public InvalidEmailException(string email)
        : base(string.IsNullOrWhiteSpace(email)
            ? "An empty address is not a valid email address."
            : $"The address '{email}' is not a valid email address."
        ) { }
}