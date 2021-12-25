using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day25Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string> { "v...>>.vv>", ".vv>>.vv..", ">>.>v>...v", ">>v>>.>.v.", "v>v.vv.v..", ">.>>..v...", ".vv..>.>v.", "v.v..>>v.v", "....v..v.>" });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day25(_testInput);
        var actual = target.PartOne();
        Assert.Equal(58, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 25);
        var target = new Day25(input);
        var actual = target.PartOne();
        Assert.Equal(458, actual);
    }
}
