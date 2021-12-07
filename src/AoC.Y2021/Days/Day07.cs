using System;
using System.Linq;
using AoC.Common;

namespace AoC.Y2021.Days;

public class Day07 : DayBase
{
    public Day07(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => GetFuelUsed(true);

    public override IComparable PartTwo() => GetFuelUsed(false);

    private int GetFuelUsed(bool constant)
    {
        var crabSubmarines = _puzzleInput.GetLine().Split(',').Select(int.Parse).ToList();
        var leastFuel = int.MaxValue;

        for (int i = crabSubmarines.Min(); i <= crabSubmarines.Max(); i++)
        {
            var fuelUsed = crabSubmarines.Sum(p =>
            {
                var steps = Math.Abs(p - i);
                return constant ? steps : (steps * (steps + 1)) / 2;
            });

            if (fuelUsed < leastFuel)
            {
                leastFuel = fuelUsed;
            }
        }

        return leastFuel;
    }
}
