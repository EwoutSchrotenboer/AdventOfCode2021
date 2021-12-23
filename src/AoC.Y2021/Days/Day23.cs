using System;
using System.Collections.Generic;
using System.Linq;
using AoC.Common;

namespace AoC.Y2021.Days;

public class Day23 : DayBase
{
    private int _hallwaySize;
    private readonly int[] _stepCost = { 1, 10, 100, 1000 };
    private readonly int[] _directions = { -1, 1 };

    public Day23(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => Organize(new CurrentState(GetInitialState(), 0));

    public override IComparable PartTwo()
    {
        var initialState = GetInitialState();
        var additional = @"
            #D#C#B#A# 
            #D#B#A#C#";

        var additionalAmphipods = additional.Where(c => c is >= 'A' and <= 'D').ToArray();
        var expandedState = initialState
            .Take(_hallwaySize + 4)
            .Concat(additionalAmphipods)
            .Concat(initialState.Skip(_hallwaySize + 4))
            .ToArray();

        return Organize(new CurrentState(expandedState, 0));
    }

    private bool IsRoomOrganized(char[] state, int depth, int r)
    {
        for (int i = depth - 1; i >= 0; i--)
        {
            var c = state[_hallwaySize + i * 4 + r];
            if (c =='.') { return true; }
            if (c != 'A' + r) { return false; }
        }

        return true;
    }

    private int RoomCount(char[] state, int depth, int r)
    {
        int count = 0;
        for (int i = depth - 1; i >= 0; i--)
        {
            var c = state[_hallwaySize + i * 4 + r];
            if (c == '.') { return count; }
            count++;
        }
        return count;
    }

    private void PushRoom(char[] state, int depth, int r, char c)
    {
        for (int i = depth - 1; i >= 0; i--)
        {
            var index = _hallwaySize + i * 4 + r;
            if (state[index] != '.') { continue; }

            state[index] = c;
            return;
        }
    }

    private void PopRoom(char[] state, int depth, int r)
    {
        for (int i = 0; i < depth; i++)
        {
            var index = _hallwaySize + i * 4 + r;
            if (state[index] == '.') { continue; }

            state[index] = '.';
            return;
        }
    }

    private char PeekRoom(char[] state, int depth, int r)
    {
        for (int i = 0; i < depth; i++)
        {
            var index = _hallwaySize + i * 4 + r;
            if (state[index] != '.')
            {
                return state[index];
            }
        }
        return default;
    }

    private List<CurrentState> GetNeighbors(int depth, CurrentState state)
    {
        var neighbors = new List<CurrentState>();

        for (int i = 0; i < _hallwaySize; i++)
        {
            if (state.State[i] == '.') { continue; }
            var picked = state.State[i];
            var pickedIndex = picked - 'A';

            bool canMoveToRoom = IsRoomOrganized(state.State, depth, pickedIndex);
            if (!canMoveToRoom) { continue; }

            var targetPosition = 2 + 2 * pickedIndex;
            var direction = targetPosition > i ? 1 : -1;
            for (int j = direction; Math.Abs(j) <= Math.Abs(targetPosition - i); j += direction)
            {
                if (state.State[i + j] != '.') { canMoveToRoom = false; break; }
            }

            if (!canMoveToRoom) { continue; }
            var newState = new char[state.State.Length];
            state.State.CopyTo(newState, 0);

            newState[i] = '.';
            PushRoom(newState, depth, pickedIndex, picked);

            var newCost = state.Cost + (Math.Abs(targetPosition - i) + (depth - RoomCount(state.State, depth, pickedIndex))) * _stepCost[pickedIndex];
            neighbors.Add(new CurrentState(newState, newCost));
        }

        if (neighbors.Count > 0) { return neighbors; }

        for (int r = 0; r < 4; r++)
        {
            if (IsRoomOrganized(state.State, depth, r)) { continue; }

            var picked = PeekRoom(state.State, depth, r);
            var pickedIndex = picked - 'A';

            var energy = state.Cost + (depth - RoomCount(state.State, depth, r) + 1) * (_stepCost[pickedIndex]);
            var roomPosition = 2 + 2 * r;
            foreach (var direction in _directions)
            {
                var distance = direction;
                while (roomPosition + distance >= 0 && roomPosition + distance < _hallwaySize && state.State[roomPosition + distance] == '.')
                {
                    if (roomPosition + distance == 2 || roomPosition + distance == 4 || roomPosition + distance == 6 || roomPosition + distance == 8)
                    {
                        distance += direction; continue;
                    }

                    var newState = new char[state.State.Length];
                    state.State.CopyTo(newState, 0);

                    newState[roomPosition + distance] = picked;
                    PopRoom(newState, depth, r);

                    neighbors.Add(new CurrentState(newState, energy + Math.Abs(distance) * _stepCost[pickedIndex]));

                    distance += direction;
                }
            }
        }

        return neighbors;
    }

    private bool IsTarget(CurrentState state, int depth)
    {
        for (int i = 0; i < _hallwaySize; i++)
        {
            if (state.State[i] != '.') { return false; }
        }

        for (int r = 0; r < 4; r++)
        {
            if (!IsRoomOrganized(state.State, depth, r)) { return false; }
        }

        return true;
    }

    private int Organize(CurrentState initialState)
    {
        var depth = (initialState.State.Length - _hallwaySize) / 4;
        var frontier = new PriorityQueue<CurrentState, int>();
        frontier.Enqueue(initialState, 0);
        var visited = new HashSet<string>();
        while (frontier.Count > 0)
        {
            var node = frontier.Dequeue();
            var stateString = new string(node.State);
            if (visited.Contains(stateString))
            {
                continue;
            }
            if (IsTarget(node, depth))
            {
                return node.Cost;
            }
            visited.Add(stateString);
            frontier.EnqueueRange(GetNeighbors(depth, node).Select(n => (n, Energy: n.Cost)));
        }

        return default;
    }

    private char[] GetInitialState()
    {
        var text = _puzzleInput.GetText();
        var initial = text.Where(c => c is '.' or >= 'A' and <= 'D').ToArray();
        _hallwaySize = initial.Count(c => c == '.');

        return initial;
    }

    private record CurrentState(char[] State, int Cost);
}
