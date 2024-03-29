using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day10Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string> { "[({(<(())[]>[[{[]{<()<>>", "[(()[<>])]({[<{<<[]>>(", "{([(<{}[<>[]}>{[]{[(<()>", "(((({<>}<{<{<>}{[]{[]{}", "[[<[([]))<([[{}[[()]]]", "[{[{({}]{}}([{[{{{}}([]", "{<[[]]>}<{[{[{[]{()[[[]", "[<(<(<(<{}))><([]([]()", "<{([([[(<>()){}]>(<<{{", "<{([{{}}[<[[[<>{}]]]>[]]"});

    [Fact]
    public void PartOneTest()
    {
        var target = new Day10(_testInput);
        var actual = target.PartOne();
        Assert.Equal(26397L, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 10);
        var target = new Day10(input);
        var actual = target.PartOne();
        Assert.Equal(294195L, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day10(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(288957L, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 10);
        var target = new Day10(input);
        var actual = target.PartTwo();
        Assert.Equal(3490802734L, actual);
    }
}
