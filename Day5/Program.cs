using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get a list of number values from the input file
            // Seat numbers are binary, MSB first, where F/L=0, B/R=1
            string inputFile = "data/day/5/input.txt";
            List<int> seats = File.ReadAllLines(inputFile).Select(
                line => Convert.ToInt32(line.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1'), 2)
            ).ToList();

            // Part 1 answer
            // Find highest numbered seat
            Console.WriteLine("Part 1 answer: {0}", seats.Max());

            // Part 2 answer
            // Find unoccupied seat where s-1 and s+1 are occupied
            seats.Sort();
            Console.WriteLine("Part 2 answer: {0}", seats.Where((seat, index) => index > 0 && seats[index - 1] == seats[index] - 2).Single() - 1);
        }
    }
}
