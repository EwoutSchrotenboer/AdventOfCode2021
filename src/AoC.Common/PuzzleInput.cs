using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC.Common;

public class PuzzleInput
{
    private readonly IEnumerable<string> _inputLines;
    private readonly string _inputText;
    private readonly List<string> _extraParameters = new();

    public PuzzleInput(IEnumerable<string> inputLines, params string[] extraParameters)
    {
        _inputLines = inputLines;
        _inputText = string.Join(Environment.NewLine, inputLines);

        if (extraParameters != null)
        {
            _extraParameters.AddRange(extraParameters);
        }
    }

    public List<List<string>> GetGroups() =>
        _inputText.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries)
        .Select(g => g.Split(Environment.NewLine).ToList()).ToList();

    public string GetText() => string.Join(Environment.NewLine, _inputLines);
    public List<string> GetLines() => _inputLines.ToList();
    public string GetLine() => _inputLines.Single();
    public List<int> GetNumbers() => _inputLines.Select(int.Parse).ToList();
    public List<long> GetLongNumbers() => _inputLines.Select(long.Parse).ToList();
    public int GetNumber() => _inputLines.Select(int.Parse).Single();
    public string GetParameter(int index) => _extraParameters[index];
}
