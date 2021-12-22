using System;
using System.Collections.Generic;
using System.Linq;
using AoC.Common;

namespace AoC.Y2021.Days;

public class Day22 : DayBase
{
    private readonly List<CubeInstruction> _instructions = new();
    private readonly List<CubeInstruction> _overlaps = new();
    public Day22(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => Reboot(true);
    public override IComparable PartTwo() => Reboot();

    public long Reboot(bool initializeOnly = false)
    {
        var instructions = _puzzleInput.GetLines().Select(ParseInstruction);
        foreach (var instruction in instructions)
        {
            if (instruction.IsRebootStep && initializeOnly) { break; }
            ProcessInstruction(instruction);
        }

        return CountEnabledCubes();
    }

    private CubeInstruction ParseInstruction(string input)
    {
        bool on = input[1] == 'n';
        int firstIndex = input.IndexOf('=') + 1;
        int secondIndex = input.IndexOf('=', firstIndex) + 1;
        int thirdIndex = input.IndexOf('=', secondIndex) + 1;
        var xRange = input[firstIndex..(secondIndex - 3)];
        var yRange = input[secondIndex..(thirdIndex - 3)];
        var zRange = input[thirdIndex..];

        var xs = xRange.Split("..").Select(int.Parse).ToArray();
        var ys = yRange.Split("..").Select(int.Parse).ToArray();
        var zs = zRange.Split("..").Select(int.Parse).ToArray();
        var cube = new Cube(xs[0], ys[0], zs[0], xs[1], ys[1], zs[1]);
        return new CubeInstruction(cube, on);
    }

    private void ProcessInstruction(CubeInstruction instruction)
    {
        _overlaps.Clear();
        foreach (var prevInstructions in _instructions)
        {
            if (instruction.IsOverlapping(prevInstructions))
            {
                var overlapCube = instruction.Overlaps(prevInstructions);
                _overlaps.Add(new CubeInstruction(overlapCube, !prevInstructions.On));
            }
        }
        _instructions.AddRange(_overlaps);

        if (instruction.On)
        {
            _instructions.Add(instruction);
        }
    }

    private long CountEnabledCubes()
    {
        long cubeOn = 0;
        foreach (var instruction in _instructions)
        {
            cubeOn += instruction.On ? instruction.Count : -instruction.Count;
        }

        return cubeOn;
    }

    private readonly struct CubeInstruction
    {
        private readonly Cube _cube;
        public readonly bool On;

        public long Count => _cube.Count;
        public CubeInstruction(in Cube cube, bool on)
        {
            _cube = cube;
            On = on;
        }

        public bool IsOverlapping(in CubeInstruction cubeInstruction) => _cube.IsOverlapping(cubeInstruction._cube);
        public Cube Overlaps(in CubeInstruction cubeInstruction) => _cube.Overlaps(cubeInstruction._cube);

        public bool IsRebootStep => _cube.MinX < -50 || _cube.MaxX > 50 ||
                                   _cube.MinY < -50 || _cube.MaxY > 50 ||
                                   _cube.MinZ < -50 || _cube.MaxZ > 50;
    }

    private readonly struct Cube
    {
        public readonly int MinX, MinY, MinZ;
        public readonly int MaxX, MaxY, MaxZ;
        private readonly long _xRange, _yRange, _zRange;
        public Cube(int minX, int minY, int minZ, int maxX, int maxY, int maxZ)
        {
            MinX = minX;
            MinY = minY;
            MinZ = minZ;
            MaxX = maxX;
            MaxY = maxY;
            MaxZ = maxZ;
            _xRange = 1 + MaxX - MinX;
            _yRange = 1 + MaxY - MinY;
            _zRange = 1 + MaxZ - MinZ;
        }

        public long Count => _xRange * _yRange * _zRange;

        public bool IsOverlapping(in Cube cube) =>
            !(MaxX < cube.MinX || MinX > cube.MaxX
           || MaxY < cube.MinY || MinY > cube.MaxY
           || MaxZ < cube.MinZ || MinZ > cube.MaxZ);

        public Cube Overlaps(in Cube cube)
        {
            var minX = Math.Max(MinX, cube.MinX);
            var minY = Math.Max(MinY, cube.MinY);
            var minZ = Math.Max(MinZ, cube.MinZ);
            var maxX = Math.Min(MaxX, cube.MaxX);
            var maxY = Math.Min(MaxY, cube.MaxY);
            var maxZ = Math.Min(MaxZ, cube.MaxZ);
            return new Cube(minX, minY, minZ, maxX, maxY, maxZ);
        }
    }
}
