using System;

namespace Peereflits.Shared.Types.Mail;

public class InvalidEmailException
(
    string email
) : Exception(string.IsNullOrWhiteSpace(email)
                      ? "An empty address is not a valid email address."
                      : $"The address '{email}' is not a valid email address."
             );