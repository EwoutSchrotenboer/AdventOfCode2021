using System;
using System.Collections.Generic;
using System.Linq;
using AoC.Common;

namespace AoC.Y2021.Days;

public class Day10 : DayBase
{
    private readonly Dictionary<char, int> _points = new() { ['('] = 1, [')'] = 3, ['['] = 2, [']'] = 57, ['{'] = 3, ['}'] = 1197, ['<'] = 4, ['>'] = 25137 };

    public Day10(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => _puzzleInput.GetLines().Sum(l => ProcessString(l, true));

    public override IComparable PartTwo()
    {
        var scores = _puzzleInput.GetLines().Select(l => ProcessString(l, false));
        return GetMiddleScore(scores.Where(s => s != 0));
    }

    private long ProcessString(string line, bool findErrors)
    {
        var startChars = new Stack<char>();

        foreach (var c in line)
        {
            if (IsStart(c)) { startChars.Push(c); }
            else
            {
                if (Pair(startChars.Peek(), c))
                {
                    startChars.Pop();
                }
                else
                {
                    return findErrors ? _points[c] : 0;
                }
            }
        }

        return findErrors ? 0 : AutoComplete(startChars);
    }


    private long AutoComplete(Stack<char> startChars)
    {
        var score = 0L;

        while (startChars.Count > 0)
        {
            score *= 5;
            score += _points[startChars.Pop()];
        }

        return score;
    }

    private bool IsStart(char c) => c is '(' or '[' or '{' or '<';

    private bool Pair(char opening, char closing) =>
        (opening, closing) switch
        {
            ('(', ')') => true,
            ('[', ']') => true,
            ('{', '}') => true,
            ('<', '>') => true,
            _ => false
        };

    private long GetMiddleScore(IEnumerable<long> scores) => scores.OrderBy(_ => _).ToList()[scores.Count() / 2];
}
