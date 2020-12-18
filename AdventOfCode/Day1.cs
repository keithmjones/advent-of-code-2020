using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day1: Day
    {
        private IEnumerable<Int64> values;

        public void ReadInputFile(string inputFile)
        {
            // Get a list of number values from the input file
            values = File.ReadAllLines(inputFile).Select(line => Int64.Parse(line));
        }

        public Int64 SolvePart1()
        {
            // Get the two numbers that add up to 2020
            return FindNumbersWithSum.Find(values, 2, 2020);
        }

        public Int64 SolvePart2()
        {
            // Get the three numbers that add up to 2020
            return FindNumbersWithSum.Find(values, 3, 2020);
        }
    }
}
