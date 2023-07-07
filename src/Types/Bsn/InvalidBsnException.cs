using System;

namespace Peereflits.Shared.Types.Bsn;

public class InvalidBsnException : Exception
{
    public InvalidBsnException(Burgerservicenummer bsn) : base($"De gegeven waarde '{bsn}' is geen valide burgerservicenummer.") { }
}