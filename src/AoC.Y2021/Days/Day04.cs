using System;
using System.Collections.Generic;
using System.Linq;
using AoC.Common;

namespace AoC.Y2021.Days;

public class Day04 : DayBase
{
    public Day04(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => PlayBingo(_puzzleInput.GetGroups(), true);

    public override IComparable PartTwo() => PlayBingo(_puzzleInput.GetGroups(), false);
    private int PlayBingo(List<List<string>> inputGroups, bool firstBingo)
    {
        var numbers = inputGroups.First()[0].Split(',').Select(int.Parse);
        var cards = inputGroups.Skip(1).Select(g => new Bingoboard(g)).ToList();

        foreach (var number in numbers)
        {
            foreach (var card in cards)
            {
                var (bingo, sumOfUnmarked) = card.AddNumber(number);

                if (bingo && (firstBingo || cards.All(c => c.Complete)))
                {
                    return sumOfUnmarked * number;
                }
            }
        }

        return -1;
    }
}

public class Bingoboard
{
    public bool Complete { get; private set; }
    private readonly Dictionary<int, Position> _spaces = new();
    private readonly Dictionary<int, Position> _called = new();

    public Bingoboard(List<string> input)
    {
        for (int y = 0; y < input.Count; y++)
        {
            var rowItems = input[y].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int x = 0; x < rowItems.Length; x++)
            {
                _spaces.Add(int.Parse(rowItems[x]), new Position(x, y));
            }
        }
    }

    public (bool bingo, int sumOfUnmarked) AddNumber(int number)
    {
        if (_spaces.ContainsKey(number))
        {
            _called.Add(number, _spaces[number]);
        }

        return CheckBingo();
    }

    private (bool bingo, int sumOfUnmarked) CheckBingo()
    {
        if (_called.Keys.Count < 5) { return (false, -1); }

        var calledSpaces = _called.Values;

        for (int i = 0; i < 5; i++)
        {
            if (calledSpaces.Count(v => v.X == i) == 5 || calledSpaces.Count(v => v.Y == i) == 5)
            {
                Complete = true;
                return (true, GetSumOfUncalled());
            }
        }

        return (false, -1);
    }

    private int GetSumOfUncalled() => _spaces.Keys.Except(_called.Keys).Sum();
}
