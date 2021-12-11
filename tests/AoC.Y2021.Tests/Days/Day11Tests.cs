using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day11Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string> { "5483143223", "2745854711", "5264556173", "6141336146", "6357385478", "4167524645", "2176841721", "6882881134", "4846848554", "5283751526" });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day11(_testInput);
        var actual = target.PartOne();
        Assert.Equal(1656, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 11);
        var target = new Day11(input);
        var actual = target.PartOne();
        Assert.Equal(1665, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day11(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(195, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 11);
        var target = new Day11(input);
        var actual = target.PartTwo();
        Assert.Equal(235, actual);
    }
}
