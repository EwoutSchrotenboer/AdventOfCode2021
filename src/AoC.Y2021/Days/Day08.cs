using System;
using System.Collections.Generic;
using System.Linq;
using AoC.Common;

namespace AoC.Y2021.Days;

public class Day08 : DayBase
{
    public Day08(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => GetEntries().Select(o => o.outputs).Sum(o => o.Count(s => MapUniqueSignals(s) != -1));

    public override IComparable PartTwo()
    {
        var entries = GetEntries();
        var outputValues = new List<string>();

        foreach (var (signals, outputs) in entries)
        {
            var mappedSignals = new string[10];

            foreach (var signal in signals)
            {
                var mapped = MapUniqueSignals(signal);
                if (mapped != -1) { mappedSignals[mapped] = signal; }
            }

            var fives = signals.Where(s => s.Length == 5).ToList();
            var sixes = signals.Where(s => s.Length == 6).ToList();

            mappedSignals[6] = GetSix(sixes, mappedSignals[1][0], mappedSignals[1][1]);
            var lowerRight = mappedSignals[6].Single(s => mappedSignals[1].Contains(s));
            var upperRight = mappedSignals[1].Single(s => s != lowerRight);

            mappedSignals[5] = fives.Single(s => !s.Contains(upperRight));
            var lowerLeft = mappedSignals[6].Single(s => !mappedSignals[5].Contains(s));

            mappedSignals[2] = fives.Single(s => !s.Contains(lowerRight));
            mappedSignals[3] = fives.Single(s => s != mappedSignals[2] && s != mappedSignals[5]);
            mappedSignals[9] = sixes.Single(s => !s.Contains(lowerLeft));
            mappedSignals[0] = sixes.Single(s => s != mappedSignals[9] && s != mappedSignals[6]);

            var orderedSignals = mappedSignals.Select(Order).ToList();

            var number = outputs.Aggregate(string.Empty, (current, output) => current + orderedSignals.IndexOf(Order(output)));
            outputValues.Add(number);
        }

        return outputValues.Sum(int.Parse);
    }

    private string Order(string value) => string.Concat(value.OrderBy(c => c));

    private int MapUniqueSignals(string input) =>
        input.Length switch
        {
            2 => 1,
            4 => 4,
            3 => 7,
            7 => 8,
            _ => -1
        };

    private string GetSix(IEnumerable<string> signals, char a, char b) =>
        signals.Single(s => s.Length == 6 && (s.Contains(a) && !s.Contains(b) || !s.Contains(a) && s.Contains(b)));

    private List<(List<string> signals, List<string> outputs)> GetEntries()
    {
        var lines = _puzzleInput.GetLines();
        var entries = new List<(List<string>, List<string>)>();

        foreach (var line in lines)
        {
            var items = line.Split(" | ");
            var signals = items[0].Split(' ').ToList();
            var outputs = items[1].Split(' ').ToList();

            entries.Add((signals, outputs));
        }

        return entries;
    }
}
