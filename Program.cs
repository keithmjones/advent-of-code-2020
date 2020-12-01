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
            int[] results = values.Where(value => values.Contains(2020 - value)).ToArray();
            Console.WriteLine("Matching rows: " + string.Join(' ', results));
            if (results.Length == 2) {
                Console.WriteLine("Part 1 Answer: " + (results[0] * results[1]));
            }
        }
    }
}
