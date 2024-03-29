using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day23Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string> { "#############", "#...........#", "###B#C#B#D###", "  #A#D#C#A#", "  #########", });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day23(_testInput);
        var actual = target.PartOne();
        Assert.Equal(12521, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 23);
        var target = new Day23(input);
        var actual = target.PartOne();
        Assert.Equal(16489, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day23(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(44169, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 23);
        var target = new Day23(input);
        var actual = target.PartTwo();
        Assert.Equal(43413, actual);
    }
}
