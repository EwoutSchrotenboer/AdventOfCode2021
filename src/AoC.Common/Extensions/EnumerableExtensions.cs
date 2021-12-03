using System.Collections.Generic;
using System.Linq;

namespace AoC.Common.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<T> Clone<T>(this IEnumerable<T> self) => self.Select(v => v);
    public static List<T> CloneList<T>(this List<T> self) => self.Clone().ToList();
}
