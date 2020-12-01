using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get a list of number values from the input file
            string inputFile = "data/day/1/input.txt";
            List<int> values = File.ReadLines(inputFile).Select(line => int.Parse(line)).ToList();

            // Get the two numbers that add up to 2020
            var sum = 2020;
            int[] results = values.Where(value => values.Contains(sum - value)).ToArray();
            Console.WriteLine("Matching rows: " + string.Join(' ', results));
            if (results.Length == 2) {
                Console.WriteLine("Part 1 Answer: " + (results[0] * results[1]));
            }

            // Get the three numbers that add up to 2020
            values.Sort();
            for (var firstIndex = 0; firstIndex < values.Count() - 2 && values[firstIndex + 2] <= sum - (values[firstIndex] + values[firstIndex + 1]); firstIndex++) {
                for (var secondIndex = firstIndex + 1; secondIndex < values.Count() - 1 && values[secondIndex + 1] <= sum - (values[firstIndex] + values[secondIndex]); secondIndex++) {
                    var valueToFind = sum - (values[firstIndex] + values[secondIndex]);
                    if (values.Where(value => value == valueToFind).Count() > 0) {
                        Console.WriteLine("Matching values: " + values[firstIndex] + " " + values[secondIndex] + " " + valueToFind);
                        Console.WriteLine("Part 2 Answer: " + (values[firstIndex] * values[secondIndex] * valueToFind));
                    }
                }
            }
        }
    }
}
