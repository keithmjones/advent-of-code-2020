using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day15: Day
    {
        private string[] input;

        public void ReadInputFile(string inputFile)
        {
            input = File.ReadAllLines(inputFile);
        }

        public Int64 SolvePart1() => Solve(input, 2020);

        public Int64 SolvePart2() => Solve(input, 30000000);

        public Int64 Solve(string[] data, Int64 count)
        {
            Int64[] startingNumbers = data[0].Split(",").Select(value => Int64.Parse(value)).ToArray();
            var ints = new Dictionary<Int64, Int64>();
            for (Int64 index = 0; index < startingNumbers.Length; index++)
            {
                ints[startingNumbers[index]] = index;
            }
            var last = 0L;
            for (Int64 index = startingNumbers.Length; index < count - 1; index++)
            {
                Int64 next = ints.ContainsKey(last) ? index - ints[last] : 0;
                ints[last] = index;
                last = next;
            }
            return last;
        }
    }
}