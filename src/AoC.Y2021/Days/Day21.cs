using System;
using System.Collections.Generic;
using AoC.Common;

namespace AoC.Y2021.Days;

public class Day21 : DayBase
{
    private readonly long[] _diracFrequency = { 1, 3, 6, 7, 6, 3, 1 };
    private readonly Dictionary<int, (long oneWins, long twoWins)> _outcomes = new();

    public Day21(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne()
    {
        var (one, two) = GetPlayers(_puzzleInput.GetLines());
        var game = new Game(one, two);
        Dice dice = new Dice();

        while (!game.Win(1000)) { game = game.Progress(dice.Roll3()); }

        return Math.Min(game.One.Score, game.Two.Score) * dice.DiceRolls;
    }


    public override IComparable PartTwo()
    {
        var (one, two) = GetPlayers(_puzzleInput.GetLines());
        var game = new Game(one, two);
        var (oneWins, twoWins) = Play(game);

        return Math.Max(oneWins, twoWins);
    }

    private (Player one, Player two) GetPlayers(List<string> lines) =>
        (new Player(lines[0][^1] - '0'), new Player(lines[1][^1] - '0'));

    private (long oneWins, long twoWins) Play(in Game game)
    {
        int hash = game.GetHashCode();
        if (_outcomes.TryGetValue(hash, out var resultCache)) { return resultCache; }

        (long oneWins, long twoWins) results = default;
        for (int diceResult = 3; diceResult <= 9; ++diceResult)
        {
            var frequency = _diracFrequency[diceResult - 3];
            var newGame = game.Progress(diceResult);

            if (newGame.One.Win(21)) { results.oneWins += frequency; }
            else if (newGame.Two.Win(21)) { results.twoWins += frequency; }
            else
            {
                var (oneWins, twoWins) = Play(newGame);
                results.oneWins += oneWins * frequency;
                results.twoWins += twoWins * frequency;
            }
        }

        _outcomes.Add(hash, results);

        return results;
    }

    private struct Dice
    {
        private int _dice;
        public int DiceRolls { get; private set; }

        public int Roll3()
        {
            int move = 0;
            for (int i = 0; i < 3; ++i) { move += Roll(); }
            return move;
        }
        int Roll()
        {
            ++DiceRolls;
            var result = ++_dice;
            if (_dice >= 100) { _dice = 0; }
            return result;
        }
    }

    private readonly struct Game
    {
        public readonly Player One;
        public readonly Player Two;
        readonly bool _turnTwo;

        public bool Win(int score) => One.Win(score) || Two.Win(score);

        public Game(Player one, Player two, bool turnTwo = false)
        {
            One = one;
            Two = two;
            _turnTwo = turnTwo;
        }
        public Game Progress(int roll) =>
            _turnTwo ? new Game(One, Two.Step(roll), !_turnTwo)
                : new Game(One.Step(roll), Two, !_turnTwo);

        public override int GetHashCode() => HashCode.Combine(One, Two, _turnTwo);
    }

    private readonly record struct Player(int _board, int Score = 0)
    {
        readonly int _board = _board;
        public int Score { get; } = Score;
        public bool Win(int score) => Score >= score;

        public Player Step(int move)
        {
            var nextMove = (_board + move - 1) % 10 + 1;
            return new Player(nextMove, Score + nextMove);
        }
    }
}
