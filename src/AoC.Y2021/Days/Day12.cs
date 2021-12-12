using System;
using System.Collections.Generic;
using AoC.Common;

namespace AoC.Y2021.Days;

public class Day12 : DayBase
{
    public Day12(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() =>  CalculateRouteCount(false);

    public override IComparable PartTwo() => CalculateRouteCount(true);

    private int CalculateRouteCount(bool visitSmallCaveTwice)
    {
        var caves = CreateMap();
        var routes = new List<string>();

        var q = new Queue<(bool, (string, string))>();
        q.Enqueue((false, ("start", "start")));

        while (q.Count > 0)
        {
            var (visitedTwice, (route, last)) = q.Dequeue();
            foreach (var a in caves[last])
            {
                var nextVisitedTwice = visitedTwice;

                if (a is "end")
                {
                    routes.Add(Next(route, a).route);
                    continue;
                }

                if (char.IsLower(a[0]))
                {
                    if ((!visitSmallCaveTwice || visitedTwice) && route.Contains(a)) { continue; }
                    nextVisitedTwice |= route.Contains(a);
                }

                q.Enqueue((nextVisitedTwice, Next(route, a)));
            }
        }

        return routes.Count;
    }

    private (string route, string last) Next(string route, string last) => ($"{route},{last}", last);

    private Dictionary<string, HashSet<string>> CreateMap()
    {
        var lines = _puzzleInput.GetLines();
        var caves = new Dictionary<string, HashSet<string>>();

        foreach (var l in lines)
        {
            var names = l.Split('-');

            if (!caves.ContainsKey(names[0])) { caves.Add(names[0], new HashSet<string>()); }
            if (!caves.ContainsKey(names[1])) { caves.Add(names[1], new HashSet<string>()); }

            if (names[1] is not "start") { caves[names[0]].Add(names[1]); }
            if (names[0] is not "start") { caves[names[1]].Add(names[0]); }
        }

        return caves;
    }
}
