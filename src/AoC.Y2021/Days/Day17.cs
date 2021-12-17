using System;
using System.Collections.Generic;
using System.Linq;
using AoC.Common;
using AoC.Common.Extensions;
using AoC.Common.Vectors;

namespace AoC.Y2021.Days;

public class Day17 : DayBase
{
    public Day17(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => GetValidTrajectories().maxHeight;
    public override IComparable PartTwo() => GetValidTrajectories().count;

    private (int maxHeight, int count) GetValidTrajectories()
    {
        var (xMin, xMax, yMin, yMax) = GetTargetArea();
        var trajectories = new List<int>();

        for (int yi = -250; yi < 250; yi++)
        {
            for (int xi = 1; xi < 100; xi++)
            {
                var (vX, vY) = (xi, yi);
                var (x, y) = (0, 0);

                var top = 0;
                var hitTarget = false;
                while (x <= xMax && y >= yMin)
                {
                    x += vX;
                    y += vY;

                    if (y > top) { top = y; }

                    if (vX > 0) { vX--; }
                    else if (vX < 0) { vX++; }
                    vY--;

                    if (x >= xMin && x <= xMax && y >= yMin && y <= yMax)
                    {
                        hitTarget = true;
                    }
                }

                if (hitTarget)
                {
                    trajectories.Add(top);
                }
            }
        }

        return (trajectories.Max(), trajectories.Count);
    }

    private (int xMin, int xMax, int yMin, int yMax) GetTargetArea()
    {
        var items = _puzzleInput.GetLine()
            .Split(new[] { "x=", "..", "y=", "target area: ", " ", "," }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        return (items[0], items[1], items[2], items[3]);
    }
}
