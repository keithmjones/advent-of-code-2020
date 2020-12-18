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

        public Int64 SolvePart1(Int64[] ints, int preambleCount)
        {
            for (int index = preambleCount; index < ints.Length; index++)
            {
                var valueToTest = ints[index];
                var arrayToTest = ints.Skip(index - preambleCount).Take(preambleCount).ToArray();
                var result = FindNumbersWithSum.Find(arrayToTest, 2, valueToTest);
                if (result == 0) return valueToTest;
            }
            Console.Error.WriteLine("All numbers conform to the rule.");
            return -1;
        }

        public Int64 SolvePart2(Int64[] ints, int preambleCount)
        {
            var invalidNumber = SolvePart1(ints, preambleCount);
            Console.Error.WriteLine("Invalid number: {0}", invalidNumber);
            Int64 result = -1;
            for (int startIndex = 0; startIndex < ints.Length - 3; startIndex++)
            {
                for (int endIndex = startIndex + 2; endIndex < ints.Length - 1; endIndex++)
                {
                    var subset = ints.Skip(startIndex).Take(endIndex - startIndex);
                    var sum = subset.Sum();
                    if (sum == invalidNumber)
                    {
                        result = subset.Min() + subset.Max();
                    }
                }
            }
            return result;
        }
    }
}
