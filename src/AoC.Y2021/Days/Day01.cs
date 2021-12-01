using System;
using System.Collections.Generic;
using AoC.Common;

namespace AoC.Y2021.Days;

public class Day01 : DayBase
{
    public Day01(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => GetDepthIncreaseCount(_puzzleInput.GetNumbers(), -1, 0);

    public override IComparable PartTwo() => GetDepthIncreaseCount(_puzzleInput.GetNumbers(), -1, 2);

    private int GetDepthIncreaseCount(List<int> depths, int a, int b)
    {
        var count = 0;
        for (int i = -a; i < depths.Count - b; i++)
        {
            if (depths[i + a] < depths[i + b]) { count++; }
        }

        return count;
    }
}
