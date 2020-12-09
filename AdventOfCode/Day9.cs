using System;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day9: Day
    {
        private Int64[] input;

        public void ReadInputFile(string inputFile)
        {
            input = File.ReadAllLines(inputFile).Select(value => Int64.Parse(value)).ToArray();
        }

        public Int64 SolvePart1() => SolvePart1(input, 25);

        public Int64 SolvePart2() => SolvePart2(input, 25);

        public Int64 SolvePart1(Int64[] ints, int preambleCount) {
            for (int i = preambleCount; i < ints.Length; i++)
            {
                var valueToTest = ints[i];
                var arrayToTest = ints.Skip(i - preambleCount).Take(preambleCount).ToArray();
                var result = FindNumbersWithSum.Find(arrayToTest, 2, valueToTest);
                if (result == 0) return valueToTest;
            }
            Console.Error.WriteLine("All numbers conform to the rule.");
            return -1;
        }

        public Int64 SolvePart2(Int64[] ints, int preambleCount) => 0;
    }
}