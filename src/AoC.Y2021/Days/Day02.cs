using System;
using System.Collections.Generic;
using System.Linq;
using AoC.Common;

namespace AoC.Y2021.Days;

public class Day02 : DayBase
{
    public Day02(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => FollowCourse(_puzzleInput.GetLines().Select(GetInstruction), false);

    public override IComparable PartTwo() => FollowCourse(_puzzleInput.GetLines().Select(GetInstruction), true);

    private int FollowCourse(IEnumerable<(string, int)> instructions, bool useAim)
    {
        var horizontal = 0;
        var depth = 0;
        var aim = 0;

        foreach (var (direction, value) in instructions)
        {
            if (direction.Equals("vertical"))
            {
                if (useAim) { aim += value; }
                else { depth += value; }
            }
            else
            {
                horizontal += value;
                if (useAim) { depth += aim * value; }
            }
        }

        return horizontal * depth;
    }

    private (string direction, int value) GetInstruction(string line)
    {
        var items = line.Split(' ');
        var direction = items[0];
        var value = int.Parse(items[1]);

        if (direction.Equals("forward")) { return (direction, value); }       
        return ("vertical", direction.Equals("down") ? value : -value);
    }
}
