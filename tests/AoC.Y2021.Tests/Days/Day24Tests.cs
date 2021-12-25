using System.Collections.Generic;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Y2021.Days;
using Xunit;

namespace AoC.Y2021.Tests.Days;

public class Day24Tests
{
    private readonly PuzzleInputProvider _puzzleInputProvider = new();
    private readonly PuzzleInput _testInput = new(new List<string>
        // Each position is determined by running 18 operations. Later operations are influenced by earlier steps
        // W always is $input, X starts each loop as 0, Y starts each loop as 0, Z carries over
        // X = Z % 26
        // Z /= 1 or 26
        // X += $value
        // X = (X != $input) ? 1 : 0
        // Y = (25 * X) + 1
        // Z *= Y
        // Z += ($input + $value) * X
      { "inp w", "mul x 0", "add x z", "mod x 26", "div z 1",  "add x 12",  "eql x w", "eql x 0", "mul y 0", "add y 25", "mul y x", "add y 1", "mul z y", "mul y 0", "add y w", "add y 4",  "mul y x", "add z y",
        "inp w", "mul x 0", "add x z", "mod x 26", "div z 1",  "add x 11",  "eql x w", "eql x 0", "mul y 0", "add y 25", "mul y x", "add y 1", "mul z y", "mul y 0", "add y w", "add y 11", "mul y x", "add z y",
        "inp w", "mul x 0", "add x z", "mod x 26", "div z 1",  "add x 13",  "eql x w", "eql x 0", "mul y 0", "add y 25", "mul y x", "add y 1", "mul z y", "mul y 0", "add y w", "add y 5",  "mul y x", "add z y",
        "inp w", "mul x 0", "add x z", "mod x 26", "div z 1",  "add x 11",  "eql x w", "eql x 0", "mul y 0", "add y 25", "mul y x", "add y 1", "mul z y", "mul y 0", "add y w", "add y 11", "mul y x", "add z y",
        "inp w", "mul x 0", "add x z", "mod x 26", "div z 1",  "add x 14",  "eql x w", "eql x 0", "mul y 0", "add y 25", "mul y x", "add y 1", "mul z y", "mul y 0", "add y w", "add y 14", "mul y x", "add z y",
        "inp w", "mul x 0", "add x z", "mod x 26", "div z 26", "add x -10", "eql x w", "eql x 0", "mul y 0", "add y 25", "mul y x", "add y 1", "mul z y", "mul y 0", "add y w", "add y 7",  "mul y x", "add z y",
        "inp w", "mul x 0", "add x z", "mod x 26", "div z 1",  "add x 11",  "eql x w", "eql x 0", "mul y 0", "add y 25", "mul y x", "add y 1", "mul z y", "mul y 0", "add y w", "add y 11", "mul y x", "add z y",
        "inp w", "mul x 0", "add x z", "mod x 26", "div z 26", "add x -9",  "eql x w", "eql x 0", "mul y 0", "add y 25", "mul y x", "add y 1", "mul z y", "mul y 0", "add y w", "add y 4",  "mul y x", "add z y",
        "inp w", "mul x 0", "add x z", "mod x 26", "div z 26", "add x -3",  "eql x w", "eql x 0", "mul y 0", "add y 25", "mul y x", "add y 1", "mul z y", "mul y 0", "add y w", "add y 6",  "mul y x", "add z y",
        "inp w", "mul x 0", "add x z", "mod x 26", "div z 1",  "add x 13",  "eql x w", "eql x 0", "mul y 0", "add y 25", "mul y x", "add y 1", "mul z y", "mul y 0", "add y w", "add y 5",  "mul y x", "add z y",
        "inp w", "mul x 0", "add x z", "mod x 26", "div z 26", "add x -5",  "eql x w", "eql x 0", "mul y 0", "add y 25", "mul y x", "add y 1", "mul z y", "mul y 0", "add y w", "add y 9",  "mul y x", "add z y",
        "inp w", "mul x 0", "add x z", "mod x 26", "div z 26", "add x -10", "eql x w", "eql x 0", "mul y 0", "add y 25", "mul y x", "add y 1", "mul z y", "mul y 0", "add y w", "add y 12", "mul y x", "add z y",
        "inp w", "mul x 0", "add x z", "mod x 26", "div z 26", "add x -4",  "eql x w", "eql x 0", "mul y 0", "add y 25", "mul y x", "add y 1", "mul z y", "mul y 0", "add y w", "add y 14", "mul y x", "add z y",
        "inp w", "mul x 0", "add x z", "mod x 26", "div z 26", "add x -5",  "eql x w", "eql x 0", "mul y 0", "add y 25", "mul y x", "add y 1", "mul z y", "mul y 0", "add y w", "add y 14", "mul y x", "add z y" });

    [Fact]
    public void PartOneTest()
    {
        var target = new Day24(_testInput);
        var actual = target.PartOne();
        Assert.Equal(92915979999498, actual);
    }

    [Fact]
    public async Task PartOne()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 24);
        var target = new Day24(input);
        var actual = target.PartOne();
        Assert.Equal(92915979999498, actual);
    }

    [Fact]
    public void PartTwoTest()
    {
        var target = new Day24(_testInput);
        var actual = target.PartTwo();
        Assert.Equal(21611513911181, actual);
    }

    [Fact]
    public async Task PartTwo()
    {
        var input = await _puzzleInputProvider.GetAsync(2021, 24);
        var target = new Day24(input);
        var actual = target.PartTwo();
        Assert.Equal(21611513911181, actual);
    }
}
