using System;
using System.Collections.Generic;
using System.Linq;
using AoC.Common;

namespace AoC.Y2021.Days;

public class Day14 : DayBase
{
    public Day14(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => CalculatePolymer(10);

    public override IComparable PartTwo() => CalculatePolymer(40);

    public long CalculatePolymer(int iterations)
    {
        var (initial, rules) = GetPolymerRules();
        var occurrences = new Dictionary<string, long>();

        for (int index = 0; index < initial.Length - 1; index++)
        {
            var v = initial.Substring(index, 2);
            if (!occurrences.ContainsKey(v)) { occurrences.Add(v, 0);}
            occurrences[v]++;
        }

        for (int i = 0; i < iterations; i++)
        {
            occurrences = Step(occurrences, rules);
        }

        var totals = GetTotals(occurrences, initial[^1]);
        return totals.Values.Max() - totals.Values.Min();
    }

    private Dictionary<string, long> Step(Dictionary<string, long> occurrences, Dictionary<string, string> rules)
    {
        var next = new Dictionary<string, long>();

        foreach (var (key, value) in occurrences)
        {
            var first = $"{key[0]}{rules[key]}";
            var second = $"{rules[key]}{key[1]}";

            if (!next.ContainsKey(first)) { next.Add(first, 0); }

            next[first] += value;

            if (!next.ContainsKey(second))
            {
                next.Add(second, 0);
            }

            next[second] += value;
        }

        return next;
    }

    private Dictionary<char, long> GetTotals(Dictionary<string, long> occurrences, char last)
    {
        var totals = new Dictionary<char, long>();

        foreach (var (key, value) in occurrences)
        {
            if (!totals.ContainsKey(key[0])) { totals.Add(key[0], 0); }
            totals[key[0]] += value;
        }

        totals[last]++;

        return totals;
    }

    private (string initial, Dictionary<string, string> rules) GetPolymerRules()
    {
        var lines = _puzzleInput.GetLines();

        var initial = lines.First();
        var rules = new Dictionary<string, string>();
        foreach (var rule in lines.Skip(2))
        {
            var items = rule.Split(" -> ");
            rules.Add(items[0], items[1]);
        }

        return (initial, rules);
    }
}
