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

        public Int64 SolvePart1() => SolvePart1(input);

        public Int64 SolvePart2() => SolvePart2(input);

        public Int64 SolvePart1(string[] data)
        {
            List<Int64> ints = data[0].Split(",").Select(value => Int64.Parse(value)).ToList();
            while (ints.Count < 2020)
            {
                Int64 last = ints.Last();
                Int64 previous = ints.FindLastIndex(
                    ints.Count - 2,
                    value => value == last
                );
                Int64 difference = previous < 0 ? 0 : ints.Count - previous - 1;
                ints.Add(difference);
            }
            return ints.Last();
        }

        public Int64 SolvePart2(string[] data)
        {
            Int64[] startingNumbers = data[0].Split(",").Select(value => Int64.Parse(value)).ToArray();
            var ints = new Dictionary<Int64, Int64>();
            for (Int64 index = 0; index < startingNumbers.Length; index++)
            {
                ints[startingNumbers[index]] = index;
            }
            var last = 0L;
            for (Int64 index = startingNumbers.Length; index < 30000000 - 1; index++)
            {
                Int64 next = ints.ContainsKey(last) ? index - ints[last] : 0;
                ints[last] = index;
                last = next;
            }
            return last;
        }
    }
}