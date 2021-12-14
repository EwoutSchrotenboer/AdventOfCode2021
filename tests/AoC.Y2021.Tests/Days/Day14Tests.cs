using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day14Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string> { "NNCB", "", "CH -> B", "HH -> N", "CB -> H", "NH -> C", "HB -> C", "HC -> B", "HN -> C", "NN -> C", "BH -> H", "NC -> B", "NB -> B", "BN -> B", "BB -> N", "BC -> B", "CC -> N", "CN -> C", });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day14(_testInput);
        var actual = target.PartOne();
        Assert.Equal(1588L, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 14);
        var target = new Day14(input);
        var actual = target.PartOne();
        Assert.Equal(3406L, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day14(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(2188189693529, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 14);
        var target = new Day14(input);
        var actual = target.PartTwo();
        Assert.Equal(3941782230241, actual);
    }
}
