using System;
using System.Collections.Generic;
using System.Linq;
using AoC.Common;
using Transformation = System.Func<AoC.Y2021.Days.Vector3, AoC.Y2021.Days.Vector3>;
namespace AoC.Y2021.Days;

public class Day19 : DayBase
{
    public Day19(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => GetBeaconList(ParseScanners(), out _).Count;
    public override IComparable PartTwo()
    {
        _ = GetBeaconList(ParseScanners(), out var scanners);
        return scanners.SelectMany(i => scanners.Select(j => Vector3.ManhattanDist(i.Position, j.Position))).Max();
    }

    public static HashSet<Vector3> GetBeaconList(Vector3[][] input, out List<ScannerPosition> scanners)
    {
        var absolute = input[0].ToHashSet();
        var unmatched = new Queue<Vector3[]>();
        scanners = new() { new(Vector3.Zero, v => v) };

        foreach (var scanner in input[1..])
            unmatched.Enqueue(scanner);

        while (unmatched.TryDequeue(out var scanner))
        {
            var matched = false;
            foreach (var transformation in SpacialTransformations)
            {
                var transformed = scanner!.Select(transformation).ToArray();
                var offset = transformed.SelectMany(i => absolute.Select(j => i - j))
                    .GroupBy(i => i).Select(i => (i.Key, Count: i.Count())).MaxBy(i => i.Count);
                if (offset.Count < 12) { continue; }

                matched = true;
                var added = transformed.Count(i => absolute.Add(i - offset.Key));
                scanners.Add((offset.Key, transformation));
                break;
            }

            if (!matched) unmatched.Enqueue(scanner);
        }

        return absolute;
    }

    public static readonly Transformation[] SpacialTransformations = {
        v => v,
        v => new(v.X, -v.Z, v.Y),
        v => new(v.X, -v.Y, -v.Z),
        v => new(v.X, v.Z, -v.Y),

        v => new(-v.Y, v.X, v.Z),
        v => new(v.Z, v.X, v.Y),
        v => new(v.Y, v.X, -v.Z),
        v => new(-v.Z, v.X, -v.Y),

        v => new(-v.X, -v.Y, v.Z),
        v => new(-v.X, -v.Z, -v.Y),
        v => new(-v.X, v.Y, -v.Z),
        v => new(-v.X, v.Z, v.Y),

        v => new(v.Y, -v.X, v.Z),
        v => new(v.Z, -v.X, -v.Y),
        v => new(-v.Y, -v.X, -v.Z),
        v => new(-v.Z, -v.X, v.Y),

        v => new(-v.Z, v.Y, v.X),
        v => new(v.Y, v.Z, v.X),
        v => new(v.Z, -v.Y, v.X),
        v => new(-v.Y, -v.Z, v.X),

        v => new(-v.Z, -v.Y, -v.X),
        v => new(-v.Y, v.Z, -v.X),
        v => new(v.Z, v.Y, -v.X),
        v => new(v.Y, -v.Z, -v.X)
    };

        private Vector3[][] ParseScanners()
        => _puzzleInput.GetGroups().Select(i => i
                .Skip(1)
                .Select(Vector3.Parse)
                .ToArray()
            ).ToArray();
}

public record struct Vector3(int X, int Y, int Z) : IComparable<Vector3>
{
    public static Vector3 Zero { get; } = new(0, 0, 0);
    public static implicit operator (int X, int Y, int Z)(Vector3 value) => (value.X, value.Y, value.Z);
    public static implicit operator Vector3((int X, int Y, int Z) value) => new(value.X, value.Y, value.Z);
    public static Vector3 Parse(string input)
        => input.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).ToArray() is { Length: 3 } v
            ? new(v[0], v[1], v[2])
            : throw new FormatException("Invalid dimension!");
    public static Vector3 operator +(Vector3 lhs, Vector3 rhs) => new(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
    public static Vector3 operator -(Vector3 lhs, Vector3 rhs) => new(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
    public static int operator *(Vector3 lhs, Vector3 rhs) => lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z;
    public static int ManhattanDist(Vector3 lhs, Vector3 rhs) => Math.Abs(lhs.X - rhs.X) + Math.Abs(lhs.Y - rhs.Y) + Math.Abs(lhs.Z - rhs.Z);
    public override string ToString() => $"{X},{Y},{Z}";
    public int CompareTo(Vector3 other)
    {
        var cx = X.CompareTo(other.X);
        if (cx != 0) return cx;
        var cy = Y.CompareTo(other.Y);
        if (cy != 0) return cy;
        var cz = Z.CompareTo(other.Z);
        return cz != 0 ? cz : 0;
    }
}

public record struct ScannerPosition(Vector3 Position, Transformation Rotation)
{
    public static implicit operator (Vector3, Transformation)(ScannerPosition value) => (value.Position, value.Rotation);
    public static implicit operator ScannerPosition((Vector3, Transformation) value) => new ScannerPosition(value.Item1, value.Item2);
}
