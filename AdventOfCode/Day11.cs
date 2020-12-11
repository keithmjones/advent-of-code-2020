using System;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day11: Day
    {
        private string[] input;

        public void ReadInputFile(string inputFile)
        {
            input = File.ReadAllLines(inputFile).ToArray();
        }

        public Int64 SolvePart1() => SolvePart1(input);

        public Int64 SolvePart2() => SolvePart2(input);

        public Int64 SolvePart1(string[] room) => 0;

        public Int64 SolvePart2(string[] room) => 0;
    }
}