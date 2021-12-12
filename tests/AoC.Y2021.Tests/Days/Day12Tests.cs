using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day12Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();

    private readonly PuzzleInput _testInput = new(new List<string> { "fs-end", "he-DX", "fs-he", "start-DX", "pj-DX", "end-zg", "zg-sl", "zg-pj", "pj-he", "RW-he", "fs-DX", "pj-RW", "zg-RW", "start-pj", "he-WI", "zg-he", "pj-fs", "start-RW" });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day12(_testInput);
        var actual = target.PartOne();
        Assert.Equal(226, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 12);
        var target = new Day12(input);
        var actual = target.PartOne();
        Assert.Equal(4413, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day12(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(3509, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 12);
        var target = new Day12(input);
        var actual = target.PartTwo();
        Assert.Equal(118803, actual);
    }
}
