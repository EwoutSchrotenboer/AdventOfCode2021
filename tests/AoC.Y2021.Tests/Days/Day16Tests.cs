using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day16Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput1 = new(new List<string> { "8A004A801A8002F478", });
    private readonly PuzzleInput _testInput2 = new(new List<string> { "04005AC33890" });
    [Fact]
    public void PartOneTest()
    {
        var target = new Day16(_testInput1);
        var actual = target.PartOne();
        Assert.Equal(16L, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 16);
        var target = new Day16(input);
        var actual = target.PartOne();
        Assert.Equal(945L, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day16(_testInput2);
        var actual = target.PartTwo();
        Assert.Equal(54L, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 16);
        var target = new Day16(input);
        var actual = target.PartTwo();
        Assert.Equal(10637009915279, actual);
    }
}
