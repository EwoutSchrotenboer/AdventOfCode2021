using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day17Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string> { "target area: x=20..30, y=-10..-5" });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day17(_testInput);
        var actual = target.PartOne();
        Assert.Equal(45, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 17);
        var target = new Day17(input);
        var actual = target.PartOne();
        Assert.Equal(23005, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day17(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(112, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 17);
        var target = new Day17(input);
        var actual = target.PartTwo();
        Assert.Equal(2040, actual);
    }
}
