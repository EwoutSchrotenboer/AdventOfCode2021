using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AoC.Common;
using AoC.Common.Extensions;

namespace AoC.Y2021.Days;

public class Day16 : DayBase
{
    public Day16(PuzzleInput input) : base(input)
    {
    }

    public override IComparable PartOne() => ProcessPacket(GetBinaryString()).versions;

    public override IComparable PartTwo() => ProcessPacket(GetBinaryString()).result;

    private (int index, long versions, long result) ProcessPacket(string binary)
    {
        var versionsSum = 0L;
        var values = new List<long>();
        var length = 0;

        versionsSum += ConvertBinary(binary[..3]);
        var type = ConvertBinary(binary[3..6]);

        if (type == 4)
        {
            var index = 6;
            var literal = string.Empty;

            while (binary[index] == '1')
            {
                literal += binary.Substring(index + 1, 4);
                index += 5;
            }

            literal += binary.Substring(index + 1, 4);
            return (index + 5, versionsSum, ConvertBinary(literal));

        }

        var lengthTypeId = binary[6];
        var subIndex = 0;
        if (lengthTypeId is '0')
        {
            var subPacketsLength = (int)ConvertBinary(binary[7..22]);
            
            while(subIndex < subPacketsLength) {

                var (index, versions, result) = ProcessPacket(binary[(22 + subIndex)..]);
                subIndex += index;
                versionsSum += versions;
                values.Add(result);
            }

            length = 22 + subPacketsLength;
        }
        else
        {
            var subPacketsCount = ConvertBinary(binary[7..18]);
            length = 18;

            for (int i = 0; i < subPacketsCount; i++)
            {
                var (index, versions, result) = ProcessPacket(binary[length..]);
                length += index;
                versionsSum += versions;
                values.Add(result);
            }
        }

        return type switch
        {
            0 => ((int)length, versionsSum, values.Sum()),
            1 => ((int)length, versionsSum, values.Product()),
            2 => ((int)length, versionsSum, values.Min()),
            3 => ((int)length, versionsSum, values.Max()),
            5 => ((int)length, versionsSum, values[0] > values[1] ? 1 : 0),
            6 => ((int)length, versionsSum, values[0] < values[1] ? 1 : 0),
            7 => ((int)length, versionsSum, values[0] == values[1] ? 1 : 0)
        };
    }

    private long ConvertBinary(string binary) => Convert.ToInt64(binary, 2);

    private string GetBinaryString() => string.Join(string.Empty,
        _puzzleInput
            .GetLine()
            .Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2)
                .PadLeft(4, '0')));
}
