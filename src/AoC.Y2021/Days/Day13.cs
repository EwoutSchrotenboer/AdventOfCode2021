using System;
using System.Collections.Generic;
using System.Linq;
using AoC.Common;

namespace AoC.Y2021.Days;

public class Day13 : DayBase
{
    public Day13(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => FoldPaper(true);

    public override IComparable PartTwo() => FoldPaper(false);

    private IComparable FoldPaper(bool onlyFirstFold)
    {
        var (folds, dots) = GetInstructions();
        foreach (var (a, v) in folds)
        {
            var next = new HashSet<(int, int)>();

            foreach (var (x, y) in dots)
            {
                if ((a is 'x' && x < v) || (a is 'y' && y < v))
                {
                    next.Add((x, y));
                }
                else if (a is 'x') { next.Add((Fold(x, v), y)); }
                else { next.Add((x, Fold(y, v))); }
            }

            if (onlyFirstFold) { return next.Count; }

            dots = next;
        }

        return GenerateImage(dots);
    }

    private string GenerateImage(HashSet<(int x, int y)> dots)
    {
        var minX = dots.Min(p => p.x);
        var minY = dots.Min(p => p.y);
        var maxX = dots.Max(p => p.x);
        var maxY = dots.Max(p => p.y);

        var image = new List<string>();
        for (int y = minY; y <= maxY; y++)
        {
            var line = string.Empty;
            for (int x = minX; x <= maxX; x++)
            {
                line += dots.Contains((x, y)) ? '#' : '.';
            }
            image.Add(line);
        }

        return string.Join(' ', image);
    }

    private int Fold(int v, int line) => v - Math.Abs(v - line) * 2;


    private (List<(char, int)> folds, HashSet<(int x, int y)> dots) GetInstructions()
    {
        var groups = _puzzleInput.GetGroups();
        var positions = new HashSet<(int, int)>();
        var folds = new List<(char, int)>();
        foreach (var line in groups[0])
        {
            var parts = line.Split(',');
            positions.Add((int.Parse(parts[0]), int.Parse(parts[1])));
        }

        foreach (var line in groups[1])
        {
            var parts = line.Split(' ')[^1].Split('=');
            folds.Add((parts[0][0], int.Parse(parts[1])));
        }

        return (folds, positions);
    }
}
