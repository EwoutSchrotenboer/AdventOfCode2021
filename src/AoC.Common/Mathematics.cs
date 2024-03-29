using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Common;

public static class Mathematics
{
    public static int Mod(int a, int b) =>
        (a % b + b) % b;
    public static long Mod(long a, long b) =>
        (a % b + b) % b;

    public static long Gcd(long a, long b)
    {
        while (b != 0L)
        {
            (a, b) = (b, a % b);
        }
        return Math.Abs(a);
    }

    public static long Gcd(params long[] numbers) =>
        numbers.Gcd();

    public static long Gcd(this IEnumerable<long> numbers) =>
        numbers.Aggregate(Gcd);

    public static long Lcm(long a, long b) =>
        Math.Abs(a * b) / Gcd(a, b);

    public static long Lcm(params long[] numbers) =>
        numbers.Lcm();

    public static long Lcm(this IEnumerable<long> numbers) =>
        numbers.Aggregate(Lcm);

    public static double Hypotenuse(params int[] numbers) => Math.Sqrt(numbers.Sum(n => Math.Pow(n, 2)));
    public static double Hypotenuse(params long[] numbers) => Math.Sqrt(numbers.Sum(n => Math.Pow(n, 2)));
    public static int Min(params int[] numbers) => numbers.Min();
    public static long Min(params long[] numbers) => numbers.Min();
    public static long Max(params int[] numbers) => numbers.Max();
    public static long Max(params long[] numbers) => numbers.Max();

}
