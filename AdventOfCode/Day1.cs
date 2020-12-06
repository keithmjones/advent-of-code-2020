using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day1: Day
    {
        private IEnumerable<int> values;

        public void ReadInputFile(string inputFile)
        {
            // Get a list of number values from the input file
            values = File.ReadAllLines(inputFile).Select(line => int.Parse(line));
        }

        public int SolvePart1()
        {
            // Get the two numbers that add up to 2020
            return Solve(values, 2, 2020);
        }

        public int SolvePart2()
        {
            // Get the three numbers that add up to 2020
            return Solve(values, 3, 2020);
        }

        public int Solve(IEnumerable<int> ints, int howManyIntsToSum, int requiredSum)
        {
            if (howManyIntsToSum == 0 || !ints.Any()) return 0;
            var head = ints.First();
            var tail = ints.Skip(1);
            if (howManyIntsToSum == 1)
            {
                if (head == requiredSum) return head;
            }
            else
            {
                var result = Solve(tail, howManyIntsToSum - 1, requiredSum - head);
                if (result != 0) return head * result;
            }
            return Solve(tail, howManyIntsToSum, requiredSum);
        }
    }
}