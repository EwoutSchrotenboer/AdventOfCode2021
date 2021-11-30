using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day19Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string>());

    [Fact]
    public void PartOneTest()
    {
        var target = new Day19(_testInput);
        var actual = target.PartOne();
        Assert.Equal(-1, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 19);
        var target = new Day19(input);
        var actual = target.PartOne();
        Assert.Equal(-1, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day19(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(-1, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 19);
        var target = new Day19(input);
        var actual = target.PartTwo();
        Assert.Equal(-1, actual);
    }
}
