using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day07Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string> { "16,1,2,0,4,2,7,1,2,14" });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day07(_testInput);
        var actual = target.PartOne();
        Assert.Equal(37, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 07);
        var target = new Day07(input);
        var actual = target.PartOne();
        Assert.Equal(342730, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day07(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(168, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 07);
        var target = new Day07(input);
        var actual = target.PartTwo();
        Assert.Equal(92335207, actual);
    }
}
