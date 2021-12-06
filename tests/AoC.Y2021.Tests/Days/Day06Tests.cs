using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day06Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string> { "3,4,3,1,2" });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day06(_testInput);
        var actual = target.PartOne();
        Assert.Equal(5934L, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 06);
        var target = new Day06(input);
        var actual = target.PartOne();
        Assert.Equal(361169L, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day06(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(26984457539L, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 06);
        var target = new Day06(input);
        var actual = target.PartTwo();
        Assert.Equal(1634946868992, actual);
    }
}
