using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day02Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string>() { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day02(_testInput);
        var actual = target.PartOne();
        Assert.Equal(150, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 02);
        var target = new Day02(input);
        var actual = target.PartOne();
        Assert.Equal(1499229, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day02(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(900, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 02);
        var target = new Day02(input);
        var actual = target.PartTwo();
        Assert.Equal(1340836560, actual);
    }
}
