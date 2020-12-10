using System;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class DaySample: Day
    {
        private Int64[] input;

        public void ReadInputFile(string inputFile)
        {
            input = File.ReadAllLines(inputFile).Select(value => Int64.Parse(value)).ToArray();
        }

        public Int64 SolvePart1() => SolvePart1(input);

        public Int64 SolvePart2() => SolvePart2(input);

        public Int64 SolvePart1(Int64[] ints) => 0;

        public Int64 SolvePart2(Int64[] ints) => 0;
    }
}