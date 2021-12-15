using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using AoC.Common;
using AoC.Common.Graphs;
using AoC.Common.Vectors;

namespace AoC.Y2021.Days;

public class Day15 : DayBase
{
    public Day15(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => GetSafestRoute(false);

    public override IComparable PartTwo() => GetSafestRoute(true);

    private long GetSafestRoute(bool useLargeMap)
    {
        var (map, lowerRight) = GetMap(useLargeMap);

        BreadthFirstSearch.Search(
            Vector2.Zero,
            c => c.NeighborsVonNeumann().Where(n => map.ContainsKey(n)).Select(n => (n, map[n])),
            c => c == lowerRight,
            out var path
        );
        return path.Last().value;
    }

    private (Dictionary<Vector2, long> map, Vector2 target) GetMap(bool large)
    {
        var tile = GetTile();
        var target = tile.Keys.Aggregate(Vector2.Zero, (a, c) => a.MaxParts(c));

        if (!large) { return (tile, target); }

        var map = new Dictionary<Vector2, long>();
        for (long y = 0; y < 5; y++)
        {
            for (long x = 0; x < 5; x++)
            {
                foreach (var kvp in tile)
                {
                    var pos = kvp.Key + new Vector2(x * (target.X + 1), y * (target.Y + 1));
                    var value = Mathematics.Mod(kvp.Value + x + y - 1, 9) + 1;
                    map[pos] = value;
                }
            }
        }
        var largeTarget = map.Keys.Aggregate(Vector2.Zero, (a, c) => a.MaxParts(c));

        return (map, largeTarget);
    }

    private Dictionary<Vector2, long> GetTile() =>
        _puzzleInput
            .GetLines()
            .SelectMany((l, y) => l.Select((r, x) => (x, y, r)))
            .ToDictionary(p => new Vector2(p.x, p.y), p => (long)(p.r - '0'));
}



