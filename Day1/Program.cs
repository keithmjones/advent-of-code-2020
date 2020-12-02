using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get a list of number values from the input file
            string inputFile = "data/day/1/input.txt";
            IEnumerable<int> values = File.ReadAllLines(inputFile).Select(line => int.Parse(line));

            // Get the two numbers that add up to 2020
            Console.WriteLine("Part 1: {0}", Solve(values, 2, 2020));

            // Get the three numbers that add up to 2020
            Console.WriteLine("Part 2: {0}", Solve(values, 3, 2020));
        }

        static int Solve(IEnumerable<int> ints, int howManyIntsToSum, int requiredSum)
        {
            if (howManyIntsToSum == 0 || !ints.Any()) return 0;
            var head = ints.First();
            var tail = ints.Skip(1);
            if (howManyIntsToSum == 1) {
                if (head == requiredSum) return head;
            } else {
                var result = Solve(tail, howManyIntsToSum - 1, requiredSum - head);
                if (result != 0) return head * result;
            }
            return Solve(tail, howManyIntsToSum, requiredSum);
        }
    }
}
