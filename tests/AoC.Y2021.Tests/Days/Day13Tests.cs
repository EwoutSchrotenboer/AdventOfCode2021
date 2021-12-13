using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day13Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string> { "6,10", "0,14", "9,10", "0,3", "10,4", "4,11", "6,0", "6,12", "4,1", "0,13", "10,12", "3,4", "3,0", "8,4", "1,10", "2,14", "8,10", "9,0", "", "fold along y=7", "fold along x=5", });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day13(_testInput);
        var actual = target.PartOne();
        Assert.Equal(17, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 13);
        var target = new Day13(input);
        var actual = target.PartOne();
        Assert.Equal(747, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day13(_testInput);
        var actual = target.PartTwo();
        Assert.Equal("##### #...# #...# #...# #####", actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 13);
        var target = new Day13(input);
        var actual = target.PartTwo();
        Assert.Equal(".##..###..#..#.####.###...##..#..#.#..# #..#.#..#.#..#....#.#..#.#..#.#..#.#..# #..#.#..#.####...#..#..#.#....#..#.#### ####.###..#..#..#...###..#....#..#.#..# #..#.#.#..#..#.#....#....#..#.#..#.#..# #..#.#..#.#..#.####.#.....##...##..#..#", actual);
    }
}
