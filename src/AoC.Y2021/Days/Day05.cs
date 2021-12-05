using System;
using System.Collections.Generic;
using System.Linq;
using AoC.Common;

namespace AoC.Y2021.Days;

public class Day05 : DayBase
{
    public Day05(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => GetOverlappingVentCount(true);

    public override IComparable PartTwo() => GetOverlappingVentCount(false);

    private int GetOverlappingVentCount(bool onlyCardinal) => GetVentMap(_puzzleInput.GetLines(), onlyCardinal).Values.Count(v => v >= 2);

    private Dictionary<(int, int), int> GetVentMap(IEnumerable<string> lines, bool onlyCardinal)
    {
        var map = new Dictionary<(int, int), int>();
        foreach (var line in lines)
        {
            List<(int x, int y)> coordinates = line.Split(" -> ").Select(c =>
            {
                var coordinateItems = c.Split(',');
                return (int.Parse(coordinateItems[0]), int.Parse(coordinateItems[1]));
            }).ToList();


            var (startX, startY) = coordinates[0];
            var (endX, endY) = coordinates[1];

            var isDiagonal = startX != endX && startY != endY;
            if (onlyCardinal && isDiagonal) { continue; }

            var range = isDiagonal
                ? GetDiagonalPositions(startX, startY, endX, endY)
                : GetCardinalPositions(startX, startY, endX, endY);

            foreach (var (x, y) in range)
            {
                if (!map.ContainsKey((x, y))) { map.Add((x, y), 0); }
                map[(x, y)]++;
            }
        }

        return map;
    }

    private IEnumerable<(int, int)> GetCardinalPositions(int x1, int y1, int x2, int y2)
    {
        if (x1 == x2)
        {
            foreach (var y in GetRange(y1, y2)) { yield return (x1, y); }
        }
        else
        {
            foreach (var x in GetRange(x1, x2)) { yield return (x, y1); }
        }
    }

    private IEnumerable<(int, int)> GetDiagonalPositions(int x1, int y1, int x2, int y2)
    {
        var count = Math.Abs(x1 - x2) + 1;
        var xRange = GetRange(x1, x2).ToList();
        var yRange = GetRange(y1, y2).ToList();

        for (int i = 0; i < count; i++)
        {
            yield return (xRange[i], yRange[i]);
        }
    }

    private IEnumerable<int> GetRange(int start, int end)
    {
        if (start < end) { for (int i = start; i <= end; i++) { yield return i; } }
        else {  for (int i = start; i >= end; i--) { yield return i; } }
    }
}
