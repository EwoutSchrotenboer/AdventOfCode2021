using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day09Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string> { "2199943210", "3987894921", "9856789892", "8767896789", "9899965678" });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day09(_testInput);
        var actual = target.PartOne();
        Assert.Equal(15, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 09);
        var target = new Day09(input);
        var actual = target.PartOne();
        Assert.Equal(425, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day09(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(1134, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 09);
        var target = new Day09(input);
        var actual = target.PartTwo();
        Assert.Equal(1135260, actual);
    }
}
