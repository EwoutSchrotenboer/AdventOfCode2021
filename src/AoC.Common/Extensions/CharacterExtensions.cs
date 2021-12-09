using System;

namespace AoC.Common.Extensions;

public static class CharacterExtensions
{
    public static int ToNumber(this char c)
    {
        if (!char.IsDigit(c)) { throw new ArgumentException("Character is not a number."); }
        return (int)char.GetNumericValue(c);
    }
}
