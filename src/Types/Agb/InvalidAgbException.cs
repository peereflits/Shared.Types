using System;

namespace Peereflits.Shared.Types.Agb;

public class InvalidAgbException : Exception
{
        
    public InvalidAgbException(): base("The provided value is not a valid AGB code.")
    {
    }
        
    public InvalidAgbException(int agbCode): base($"The provided value '{agbCode}' is not a valid AGB code.")
    {
    }
}