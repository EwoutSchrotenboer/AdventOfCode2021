using System;
using System.Collections.Generic;
using System.Linq;
using AoC.Common;

namespace AoC.Y2021.Days;

public class Day06 : DayBase
{
    public Day06(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => SimulatePopulationGrowth(80);

    public override IComparable PartTwo() => SimulatePopulationGrowth(256);

    private long SimulatePopulationGrowth(int days)
    {
        var startPopulation = GetStartPopulation();
        var fishAges = new long[9];

        foreach (var age in startPopulation)
        {
            fishAges[age]++;
        }

        for (int i = 0; i < days; i++)
        {
            var newFish = fishAges[0];
            for (int index = 1; index < fishAges.Length; index++)
            {
                fishAges[index - 1] = fishAges[index];
            }

            fishAges[8] = newFish;
            fishAges[6] += newFish;
        }

        return fishAges.Sum();
    }

    private IEnumerable<int> GetStartPopulation() => _puzzleInput.GetLine().Split(',').Select(int.Parse);
}
