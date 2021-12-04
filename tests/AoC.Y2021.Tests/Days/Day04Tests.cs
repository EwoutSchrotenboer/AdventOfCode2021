using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day04Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string>
    {
        "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
        "",
        "22 13 17 11  0", " 8  2 23  4 24", "21  9 14 16  7", " 6 10  3 18  5", " 1 12 20 15 19",
        "",
        " 3 15  0  2 22", " 9 18 13 17  5", "19  8  7 25 23", "20 11 10 24  4", "14 21 16 12  6",
        "",
        "14 21 17 24  4", "10 16 15  9 19", "18  8 23 26 20", "22 11 13  6  5", " 2  0 12  3  7"
    });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day04(_testInput);
        var actual = target.PartOne();
        Assert.Equal(4512, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 04);
        var target = new Day04(input);
        var actual = target.PartOne();
        Assert.Equal(8580, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day04(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(1924, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 04);
        var target = new Day04(input);
        var actual = target.PartTwo();
        Assert.Equal(9576, actual);
    }
}
