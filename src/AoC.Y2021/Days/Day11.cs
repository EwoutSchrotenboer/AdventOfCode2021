using System;
using System.Collections.Generic;
using System.Linq;
using AoC.Common;

namespace AoC.Y2021.Days;

public class Day11 : DayBase
{
    public Day11(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => Simulate(false, 100).flashes;

    public override IComparable PartTwo() => Simulate(true).step;

    private (int step, int flashes) Simulate(bool indefinite, int steps = 0)
    {
        var grid = GetOctopusGrid();
        var step = 0;
        var flashes = 0;
        while (indefinite || step < steps)
        {
            step++;
            flashes += Step(grid);

            if (grid.Values.All(v => v == 0))
            {
                return (step, flashes);
            }
        }

        return (step, flashes);
    }

    private int Step(Dictionary<(int, int), int> grid)
    {
        var flashes = 0;
        foreach (var pos in grid.Keys) { grid[pos]++; }

        var flashed = new HashSet<(int, int)>();
        var toFlash = new Queue<(int, int)>(grid.Where(o => o.Value > 9).Select(o => o.Key));

        while (toFlash.Count > 0)
        {
            var current = toFlash.Dequeue();
            if (!flashed.Add(current)) { continue; }

            flashes++;
            var neighbors = GetNeighbours(current).Where(grid.ContainsKey);

            foreach (var n in neighbors)
            {
                grid[n]++;

                if (grid[n] > 9 && !flashed.Contains(n))
                {
                    toFlash.Enqueue(n);
                }
            }
        }

        foreach (var f in flashed)
        {
            grid[f] = 0;
        }

        return flashes;
    }

    private Dictionary<(int, int), int> GetOctopusGrid()
    {
        var lines = _puzzleInput.GetLines();
        var grid = new Dictionary<(int, int), int>();

        for (int y = 0; y < lines.Count; y++)
        {
            for (int x = 0; x < lines[0].Length; x++)
            {
                grid.Add((x, y), int.Parse($"{lines[y][x]}"));
            }
        }

        return grid;
    }

    private IEnumerable<(int, int)> GetNeighbours((int, int) pos)
    {
        var (x, y) = pos;
        yield return (x - 1, y - 1);
        yield return (x - 1, y);
        yield return (x - 1, y + 1);

        yield return (x, y - 1);
        yield return (x, y + 1);

        yield return (x + 1, y - 1);
        yield return (x + 1, y);
        yield return (x + 1, y + 1);
    }
}
