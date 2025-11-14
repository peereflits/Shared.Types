using System;

namespace Peereflits.Shared.Types.Bsn;

public class InvalidBsnException
(
    Burgerservicenummer bsn
) : Exception($"De gegeven waarde '{bsn}' is geen valide burgerservicenummer.");