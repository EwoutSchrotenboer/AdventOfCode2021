﻿using System;

namespace AoC.Common;

public abstract class DayBase
{
    internal readonly PuzzleInput _puzzleInput;

    public DayBase(PuzzleInput puzzleInput)
    {
        _puzzleInput = puzzleInput;
    }

    public abstract IComparable PartOne();

    public abstract IComparable PartTwo();
}
