using System;
using System.Collections.Generic;

namespace Peereflits.Shared.Types.Phone;

public class PhoneNumberException : Exception
{
    private const string BaseMessage = "Het telefoonnummer is onjuist";
    private const string ListPrefix = "\r\n- ";

    public PhoneNumberException() : base(BaseMessage) { }
    public PhoneNumberException(string error) : this(new[] { error }) { }
    public PhoneNumberException(IEnumerable<string> errors)
        : base($"{BaseMessage}:{ListPrefix}{string.Join(ListPrefix, errors)}") { }
}