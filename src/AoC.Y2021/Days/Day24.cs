using System;
using System.Collections.Generic;
using System.Linq;
using AoC.Common;

namespace AoC.Y2021.Days;

public class Day24 : DayBase
{
    public Day24(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => TransformToSerial(RunSerials(true));

    public override IComparable PartTwo() => TransformToSerial(RunSerials(false));

    private Dictionary<int, int> RunSerials(bool getMax)
    {
        var pairs = GetPairs();
        var stack = new Stack<(int, int)>();
        var keys = new Dictionary<int, (int x, int y)>();

        foreach (var ((n, m), i) in pairs.Select((pair, i) => (pair, i)))
        {
            if (n > 0)
            {
                stack.Push((i, m));
            }
            else
            {
                var (j, address) = stack.Pop();
                keys[i] = (j, address + n);
            }
        }

        return GenerateOutput(keys, getMax);
    }

    private Dictionary<int, int> GenerateOutput(Dictionary<int, (int x, int y)> keys, bool getMax)
    {
        var output = new Dictionary<int, int>();

        foreach (var (key, (x, y)) in keys)
        {
            output[key] = getMax ? Math.Min(9, 9 + y) : Math.Max(1, 1 + y);
            output[x] = getMax ? Math.Min(9, 9 - y) : Math.Max(1, 1 - y);
        }

        return output;
    }

    private List<(int, int)> GetPairs()
    {
        var lines = _puzzleInput.GetLines();
        return Enumerable.Range(0, 14)
            .Select(i => (
                int.Parse(lines[i * 18 + 5][6..]),
                int.Parse(lines[i * 18 + 15][6..])))
            .ToList();
    }

    private long TransformToSerial(Dictionary<int, int> digits) => long.Parse(string.Join("", digits.OrderBy(x => x.Key).Select(x => x.Value)));
}
