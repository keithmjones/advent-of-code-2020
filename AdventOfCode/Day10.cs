using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day10: Day
    {
        private Int64[] input;

        public void ReadInputFile(string inputFile)
        {
            input = File.ReadAllLines(inputFile).Select(value => Int64.Parse(value)).ToArray();
        }

        public Int64 SolvePart1() => SolvePart1(input);

        public Int64 SolvePart2() => SolvePart2(input);

        public Int64 SolvePart1(Int64[] ints)
        {
            Array.Sort(ints);
            var ones = 0;
            var threes = 0;
            Int64 last = 0;
            foreach (var value in ints)
            {
                var difference = value - last;
                if (difference == 1) ones++;
                if (difference == 3) threes++;
                last = value;
            }
            threes++; // our device is rated 3 jolts higher than highest rated adapter
            return ones * threes;
        }

        public Int64 SolvePart2(Int64[] ints) => 0;
    }
}