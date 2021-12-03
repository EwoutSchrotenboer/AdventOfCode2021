using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day03Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string>() { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day03(_testInput);
        var actual = target.PartOne();
        Assert.Equal(198, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 03);
        var target = new Day03(input);
        var actual = target.PartOne();
        Assert.Equal(3242606, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day03(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(230, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 03);
        var target = new Day03(input);
        var actual = target.PartTwo();
        Assert.Equal(4856080, actual);
    }
}
