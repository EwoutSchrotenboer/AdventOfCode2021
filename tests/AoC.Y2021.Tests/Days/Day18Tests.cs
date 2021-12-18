using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day18Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string> { "[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]", "[[[5,[2,8]],4],[5,[[9,9],0]]]", "[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]", "[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]", "[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]", "[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]", "[[[[5,4],[7,7]],8],[[8,3],8]]", "[[9,3],[[9,9],[6,[4,9]]]]", "[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]", "[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]", });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day18(_testInput);
        var actual = target.PartOne();
        Assert.Equal(4140, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 18);
        var target = new Day18(input);
        var actual = target.PartOne();
        Assert.Equal(3892, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day18(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(3993, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 18);
        var target = new Day18(input);
        var actual = target.PartTwo();
        Assert.Equal(4909, actual);
    }
}
