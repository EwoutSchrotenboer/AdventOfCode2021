using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day05Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string> { "0,9 -> 5,9", "8,0 -> 0,8", "9,4 -> 3,4", "2,2 -> 2,1", "7,0 -> 7,4", "6,4 -> 2,0", "0,9 -> 2,9", "3,4 -> 1,4", "0,0 -> 8,8", "5,5 -> 8,2" });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day05(_testInput);
        var actual = target.PartOne();
        Assert.Equal(5, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 05);
        var target = new Day05(input);
        var actual = target.PartOne();
        Assert.Equal(8622, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day05(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(12, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 05);
        var target = new Day05(input);
        var actual = target.PartTwo();
        Assert.Equal(22037, actual);
    }
}
