using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC.Common;
using AoC.Common.Extensions;

namespace AoC.Y2021.Days;

public class Day20 : DayBase
{
    public Day20(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => RunEnhancer(2);
    public override IComparable PartTwo() => RunEnhancer(50);

    private int RunEnhancer(int n)
    {
        var (algorithm, image) = ParseImage(n);

        for (int i = 0; i < n; i++)
        {
            image = ApplyAlgorithm(image, algorithm);
        }

        return image.Sum(row => row.Count(c => c == '#'));
    }

    private (string, List<List<char>>) ParseImage(int padding)
    {
        var lines = _puzzleInput.GetLines();
        var image = new List<List<char>>();

        var algorithm = lines[0];

        lines.GetRange(2, lines.Count - 2).ForEach(line => { image.Add(line.ToList()); });

        image = PadImage(image, padding);

        return (algorithm, image);
    }

    private bool IsInImage((int x, int y) position, List<List<char>> image) => position.y >= 0 && position.y < image.Count && position.x >= 0 && position.x < image[position.y].Count;

    private char GetAlgorithmValue((int x, int y) index, List<List<char>> image, string algorithm)
    {
        var algorithmIndex = string.Empty;

        for (int y = index.y - 1; y <= index.y + 1; y++)
        {
            for (int x = index.x - 1; x <= index.x + 1; x++)
            {
                algorithmIndex += (IsInImage((x, y), image) ? image[y][x] : image[index.y][index.x]) == '#' ? '1' : '0';
            }
        }

        return algorithm[Convert.ToInt32(algorithmIndex, 2)];
    }

    private List<List<char>> PadImage(List<List<char>> image, int padding)
    {
        var newImage = new List<List<char>>();

        for (int i = 0; i < padding; i++)
        {
            newImage.Add(new string('.', image.First().Count + padding * 2).ToList());
        }

        foreach (var row in image)
        {
            var newRow = new List<char>();
            for (int i = 0; i < padding; i++) { newRow.Add('.'); }
            newRow.AddRange(row);

            for (int i = 0; i < padding; i++) { newRow.Add('.'); }
            newImage.Add(newRow);
        }

        for (int i = 0; i < padding; i++)
        {
            newImage.Add(new string('.', image.First().Count + padding * 2).ToList());
        }

        return newImage;
    }

    private List<List<char>> CloneImage(List<List<char>> image) => image.Select(i => i.Clone().ToList()).ToList();

    private List<List<char>> ApplyAlgorithm(List<List<char>> image, string algorithm)
    {
        var oldImage = CloneImage(image);
        var newImage = CloneImage(image);

        for (var y = 0; y < newImage.Count; y++)
        {
            for (var x = 0; x < newImage[y].Count; x++)
            {
                newImage[y][x] = GetAlgorithmValue((x, y), oldImage, algorithm);
            }
        }

        return newImage;
    }
}
