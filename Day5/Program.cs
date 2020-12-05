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
            string inputFile = "data/day/5/input.txt";
            List<int> seats = File.ReadLines(inputFile).Select(
                line => Convert.ToInt32(line.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1'), 2)
            ).ToList();
            seats.Sort();

            // Part 1 answer
            int max = seats.Max();
            Console.WriteLine("Part 1 answer: {0}", max);

            // Part 2 answer
            // Find unoccupied seat where s-1 and s+1 are occupied
            int mySeat = -1;
            int lastSeat = -1;
            foreach (int seat in seats) {
                if (lastSeat > 0 && seat == lastSeat + 2) {
                    mySeat = seat - 1;
                    Console.WriteLine("Part 2 answer: {0}", mySeat);
                } else {
                    lastSeat = seat;
                }
            }
        }
    }
}
