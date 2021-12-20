using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day20Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string>
    {
        "..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..###..######.###...####..#..#####..##..#.#####...##.#.#..#.##..#.#......#.###.######.###.####...#.##.##..#..#..#####.....#.#....###..#.##......#.....#..#..#..##..#...##.######.####.####.#.#...#.......#..#.#.#...####.##.#......#..#...##.#.##..#...##.#.##..###.#......#.#.......#.#.#.####.###.##...#.....####.#..#..#.##.#....##..#.####....##...##..#...#......#.#.......#.......##..####..#...#.#.#...##..#.#..###..#####........#..####......#..#",
        "",
        "#..#.","#....","##..#","..#..","..###",
    });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day20(_testInput);
        var actual = target.PartOne();
        Assert.Equal(35, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 20);
        var target = new Day20(input);
        var actual = target.PartOne();

        Assert.Equal(5249, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day20(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(3351, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 20);
        var target = new Day20(input);
        var actual = target.PartTwo();
        Assert.Equal(15714, actual);
    }
}
