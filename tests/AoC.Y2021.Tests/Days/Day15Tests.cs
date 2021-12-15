using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day15Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string> { "1163751742", "1381373672", "2136511328", "3694931569", "7463417111", "1319128137", "1359912421", "3125421639", "1293138521", "2311944581" });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day15(_testInput);
        var actual = target.PartOne();
        Assert.Equal(40L, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 15);
        var target = new Day15(input);
        var actual = target.PartOne();
        Assert.Equal(527L, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day15(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(315L, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 15);
        var target = new Day15(input);
        var actual = target.PartTwo();
        Assert.Equal(2887L, actual);
    }
}
