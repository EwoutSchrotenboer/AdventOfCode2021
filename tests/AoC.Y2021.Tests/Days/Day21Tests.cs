using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day21Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string> { "Player 1 starting position: 4", "Player 2 starting position: 8" });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day21(_testInput);
        var actual = target.PartOne();
        Assert.Equal(739785, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 21);
        var target = new Day21(input);
        var actual = target.PartOne();
        Assert.Equal(864900, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day21(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(444356092776315, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 21);
        var target = new Day21(input);
        var actual = target.PartTwo();
        Assert.Equal(575111835924670, actual);
    }
}
