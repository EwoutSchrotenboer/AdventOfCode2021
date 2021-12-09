using System;
using System.Collections.Generic;
using System.Linq;
using AoC.Common;
using AoC.Common.Extensions;

namespace AoC.Y2021.Days;

public class Day09 : DayBase
{
    public Day09(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => GetRiskLevels().Sum();

    public override IComparable PartTwo() => GetBasinSizes().OrderByDescending(_ => _).Take(3).Product();

    private IEnumerable<int> GetRiskLevels()
    {
        var map = GetHeightMap();
        return map.Keys.Where(k => GetNeighbours(k).All(n => !map.ContainsKey(n) || map[k] < map[n]))
            .Select(k => map[k] + 1);
    }

    private IEnumerable<int> GetBasinSizes()
    {
        var map = GetHeightMap();
        var basins = new List<List<(int, int)>>();
        var assigned = new HashSet<(int, int)>();
        var queue = new Queue<(int, int)>();
        foreach (var (pos, _) in map.Where(v => v.Value != 9))
        {
            if (assigned.Contains(pos)) { continue; }
            var basin = new List<(int, int)>();

            queue.Enqueue(pos);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (!assigned.Add(current))
                {
                    continue;
                }
                basin.Add(current);

                var surrounding = GetNeighbours(current)
                    .Where(a =>
                        !assigned.Contains(a) &&
                        !queue.Contains(a) &&
                        map.ContainsKey(a) &&
                        map[a] != 9);

                foreach (var neighbor in surrounding)
                {
                    queue.Enqueue(neighbor);
                }
            }

            basins.Add(basin);
        }

        return basins.Select(b => b.Count);
    }

    private Dictionary<(int, int), int> GetHeightMap()
    {
        var lines = _puzzleInput.GetLines();
        var map = new Dictionary<(int, int), int>();
        for (int y = 0; y < lines.Count; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                map.Add((x, y), lines[y][x].ToNumber());
            }
        }

        return map;
    }

    private IEnumerable<(int, int)> GetNeighbours((int, int) pos)
    {
        var (x, y) = pos;
        yield return (x - 1, y);
        yield return (x, y + 1);
        yield return (x + 1, y);
        yield return (x, y - 1);
    }
}
