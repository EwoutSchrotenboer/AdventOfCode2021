using System;
using System.Collections.Generic;
using System.Linq;
using AoC.Common;
using AoC.Common.Extensions;

namespace AoC.Y2021.Days;

public class Day03 : DayBase
{
    public Day03(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne()
    {
        var diagnostics = _puzzleInput.GetLines();
        var length = diagnostics[0].Length;

        var gamma = string.Empty;
        var epsilon = string.Empty;


        for (int i = 0; i < length; i++)
        {
            gamma += GetPositionValue(diagnostics, i, true);
            epsilon += GetPositionValue(diagnostics, i, false);
        }

        return CalculateValue(gamma, epsilon);
    }

    public override IComparable PartTwo()
    {
        var diagnostics = _puzzleInput.GetLines();
        var length = diagnostics.First().Length;

        var oxygenValues = diagnostics.CloneList();
        var co2Values = diagnostics.CloneList();

        for (int i = 0; i < length; i++)
        {
            if (oxygenValues.Count > 1) { oxygenValues = FilterOnPosition(oxygenValues, i, true); }
            if (co2Values.Count > 1) { co2Values = FilterOnPosition(co2Values, i, false); }
        }

        return CalculateValue(oxygenValues[0], co2Values[0]);
    }

    private static List<string> FilterOnPosition(List<string> values, int position, bool mode)
    {
        var positionValue = GetPositionValue(values, position, mode);
        return values.Where(v => v[position].Equals(positionValue)).ToList();
    }

    private static char GetPositionValue(IEnumerable<string> values, int position, bool mode)
    {
        var characters = values
            .Select(v => v[position])
            .GroupBy(v => v)
            .OrderByDescending(v => v.Count())
            .ToList();

        if (characters.First().Count() == characters.Last().Count()) { return mode ? '1' : '0'; }
        return mode ? characters.First().Key : characters.Last().Key;
    }

    private static int CalculateValue(string first, string second) =>
        Convert.ToInt32(first, 2) * Convert.ToInt32(second, 2);
}
