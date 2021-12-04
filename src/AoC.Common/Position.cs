using System;
using System.Collections.Generic;

namespace AoC.Common;

public class Position : IEquatable<Position>
{
    public int X { get; }
    public int Y { get; }
    public int Z { get; }
    public int W { get; }

    public Position() : this(0, 0, 0) { }
    public Position(int x, int y) : this(x, y, 0) { }
    public Position(int x, int y, int z) : this(x, y, z, 0) { }
    public Position(int x, int y, int z, int w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }


    public (int x, int y) Plane() => (X, Y);
    public (int x, int y, int z) Space() => (X, Y, Z);
    public (int x, int y, int z, int w) Hyper() => (X, Y, Z, W);

    public Position Next(int vX, int vY, int vZ = 0, int vW = 0) => Next((vX, vY, vZ, vW));
    public Position Next((int x, int y) v) => new(X + v.x, Y + v.y);
    public Position Next((int x, int y, int z) v) => new(X + v.x, Y + v.y, Z + v.z);
    public Position Next((int x, int y, int z, int w) v) => new(X + v.x, Y + v.y, Z + v.z, W + v.w);

    public int Manhattan() => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z) + Math.Abs(W);

    public IEnumerable<Position> GetSurroundingHyperCube()
    {
        foreach (var vW in new int[] { -1, 0, 1 })
        {
            foreach (var nextPos in GetSurroundingCube(vW))
            {
                yield return nextPos;
            }
        }
    }

    public IEnumerable<Position> GetSurroundingCube(int vW = 0)
    {
        foreach (var vZ in new int[] { -1, 0, 1 })
        {
            foreach (var nextPos in GetSurroundingPlane(vZ, vW))
            {
                yield return nextPos;
            }
        }
    }

    public IEnumerable<Position> GetSurroundingPlane(int vZ = 0, int vW = 0)
    {
        yield return Next((-1, -1, vZ, vW));
        yield return Next((0, -1, vZ, vW));
        yield return Next((1, -1, vZ, vW));

        yield return Next((-1, 0, vZ, vW));
        if (vZ != 0 || vW != 0) { yield return Next((0, 0, vZ, vW)); }
        yield return Next((1, 0, vZ, vW));

        yield return Next((-1, 1, vZ, vW));
        yield return Next((0, 1, vZ, vW));
        yield return Next((1, 1, vZ, vW));
    }

    public bool Equals(Position? other) =>
        other != null &&
        X == other.X &&
        Y == other.Y &&
        Z == other.Z &&
        W == other.W;

    public override bool Equals(object? obj) =>
        obj != null &&
        Equals(obj as Position);

    public override int GetHashCode() => 397 ^ X ^ Y ^ Z ^ W;
}
