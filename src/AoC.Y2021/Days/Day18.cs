using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AoC.Common;

namespace AoC.Y2021.Days;

public class Day18 : DayBase
{
    public Day18(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne()
    {
        var snailNumbers = _puzzleInput.GetLines().Select(ReadSnail).ToArray();
        var snailNumber = snailNumbers[0];
        snailNumber.Reduce();

        for (int i = 1; i < snailNumbers.Length; i++)
        {
            snailNumbers[i].Reduce();
            snailNumber = snailNumber.Add(snailNumbers[i]);
            snailNumber.Reduce();
        }

        return snailNumber.Magnitude;
    }

    public override IComparable PartTwo()
    {
        var lines = _puzzleInput.GetLines();
        var max = 0;
        for (int firstIndex = 0; firstIndex < lines.Count; firstIndex++)
        {
            for (int secondIndex = 0; secondIndex < lines.Count; secondIndex++)
            {
                if (firstIndex == secondIndex) { continue; }

                var first = ReadSnail(lines[firstIndex]);
                var second = ReadSnail(lines[secondIndex]);
                first.Reduce();
                second.Reduce();

                var sum = first.Add(second);
                sum.Reduce();
                var magnitude = sum.Magnitude;
                if (magnitude > max) { max = magnitude; }
            }
        }

        return max;
    }

    private SnailNumber ReadSnail(string number) => ReadSnail(number, 0, 0).snail;

    private (SnailNumber snail, int pos) ReadSnail(string number, int start, int depth)
    {
        if (number[start] == '[')
        {
            var (left, posRight) = ReadSnail(number, start + 1, depth + 1);
            var (right, posLeft) = ReadSnail(number, posRight + 1, depth + 1);
            var snail = new SnailNumber { Left = left, Right = right, Depth = depth };
            left!.Parent = snail;
            right!.Parent = snail;
            return (snail, posLeft + 1);
        }

        var value = 0;
        var pos = start;
        while (number[pos] >= '0' && number[pos] <= '9')
        {
            value = value * 10 + (number[pos] - '0');
            pos++;
        }
        return (new SnailNumber { Value = value, Depth = depth }, pos);
    }

    private class SnailNumber : IEnumerable<SnailNumber>
    {
        public int? Value { get; set; }
        public SnailNumber? Left { get; set; }
        public SnailNumber? Right { get; set; }
        public SnailNumber? Parent { get; set; }
        public int Depth { get; set; }
        public int Magnitude => Value ?? Left!.Magnitude * 3 + Right!.Magnitude * 2;
        private bool IsPair => !Value.HasValue && Left?.Value is not null && Right?.Value is not null;
        private SnailNumber Top => Parent is null ? this : Parent.Top;

        public void Reduce()
        {
            while (true)
            {
                var toExplode = this.FirstOrDefault(s => s.Depth == 4 && s.IsPair);
                if (toExplode is not null) { toExplode.Explode(); continue; }

                var toSplit = this.FirstOrDefault(s => s.Value > 9);
                if (toSplit is not null) { toSplit.Split(); continue; }
                break;
            }
        }

        public SnailNumber Add(SnailNumber snailNumber)
        {
            var depth = Depth;
            foreach (var s in this) { s.Depth++; }
            foreach (var s in snailNumber) { s.Depth++; }

            var parent = new SnailNumber
            {
                Left = this,
                Right = snailNumber,
                Depth = depth,
            };
            Parent = parent;
            snailNumber.Parent = parent;
            return parent;
        }

        private void Explode()
        {
            var previous = Top.Where(x => x.Value.HasValue).TakeWhile(x => x != this.Left).LastOrDefault();
            if (previous is not null) { previous.Value += Left?.Value; }

            var next = Top.Where(x => x.Value.HasValue).SkipWhile(x => x != this.Right).Skip(1).FirstOrDefault();
            if (next is not null) { next.Value += Right?.Value; }

            Left = null;
            Right = null;
            Value = 0;
        }

        private void Split()
        {
            if (Value is null) { return; }
            Left = new SnailNumber { Value = (int)Math.Floor((double)Value / 2), Depth = Depth + 1, Parent = this };
            Right = new SnailNumber { Value = (int)Math.Ceiling((double)Value / 2), Depth = Depth + 1, Parent = this };
            Value = null;
        }

        public IEnumerator<SnailNumber> GetEnumerator()
        {
            yield return this;
            if (Value.HasValue) { yield break; }
            foreach (var snail in Left ?? Enumerable.Empty<SnailNumber>()) { yield return snail; }
            foreach (var snail in Right ?? Enumerable.Empty<SnailNumber>()) { yield return snail; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
