using System.Collections.Generic;
using System.Linq;

namespace AoC.Common.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<T> Clone<T>(this IEnumerable<T> self) => self.Select(v => v);
    public static List<T> CloneList<T>(this List<T> self) => self.Clone().ToList();

    public static int Product(this IEnumerable<int> value) => value.Aggregate((v, n) => v * n);
    public static long Product(this IEnumerable<long> value) => value.Aggregate((v, n) => v * n);
}
