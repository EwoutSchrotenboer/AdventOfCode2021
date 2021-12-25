using System;
using System.Collections.Generic;
using System.Linq;
using AoC.Common;

namespace AoC.Y2021.Days;

public class Day25 : DayBase
{
    public Day25(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne()
    {
        var cucumberTypes = new List<(char c, (int x, int y))> { ('>', (0, 1)), ('v', (1, 0)) };
        var patch = GetCucumberPatch();

        var yMax = patch.Length;
        var xMax = patch[0].Length;

        for (int step = 1; step < int.MaxValue; step++)
        {
            var moved = false;
            foreach (var (c, (yv, xv)) in cucumberTypes)
            {
                var next = ClonePatch(patch);
                for (int y = 0; y < yMax; y++)
                {
                    for (int x = 0; x < xMax; x++)
                    {
                        var (ya, xa) = ((y + yv) % yMax, (x + xv) % xMax);
                        if (patch[y][x] == c && patch[ya][xa] == '.')
                        {
                            next[ya][xa] = c;
                            next[y][x] = '.';
                            moved = true;
                        }
                    }
                }

                patch = next;
            }

            if (!moved) { return step; }
        }

        return -1;
    }

    private char[][] ClonePatch(char[][] patch) => patch.Select(l => l.ToArray()).ToArray();
    private char[][] GetCucumberPatch() => _puzzleInput.GetLines().Select(l => l.ToArray()).ToArray();

    public override IComparable PartTwo() => -1;
}
