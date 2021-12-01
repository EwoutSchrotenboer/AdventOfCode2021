using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day01Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string>() { "199", "200", "208", "210", "200", "207", "240", "269", "260", "263" });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day01(_testInput);
        var actual = target.PartOne();
        Assert.Equal(7, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 1);
        var target = new Day01(input);
        var actual = target.PartOne();
        Assert.Equal(1602, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day01(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(5, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 1);
        var target = new Day01(input);
        var actual = target.PartTwo();
        Assert.Equal(1633, actual);
    }
}
