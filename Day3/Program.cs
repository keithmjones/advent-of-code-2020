using System;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get a list of number values from the input file
            string inputFile = "data/day/3/input.txt";
            string[] map = File.ReadAllLines(inputFile);

            // Part 1
            var trees1x3 = CalculateNumberOfTreesEncountered(map, 1, 3);
            Console.WriteLine("Part 1 answer: {0}", trees1x3);

            // Part 2
            var trees1x1 = CalculateNumberOfTreesEncountered(map, 1, 1);
            var trees1x5 = CalculateNumberOfTreesEncountered(map, 1, 5);
            var trees1x7 = CalculateNumberOfTreesEncountered(map, 1, 7);
            var trees2x1 = CalculateNumberOfTreesEncountered(map, 2, 1);
            var product = trees1x1 * trees1x3 * trees1x5 * trees1x7 * trees2x1;
            Console.WriteLine("Part 2 answer: {0}", product);
        }

        static int CalculateNumberOfTreesEncountered(string[] map, int dy, int dx) {
            var trees = 0;
            for (var line = dy; line < map.Length; line += dy) {
                if (map[line][(dx * line / dy) % map[line].Length] == '#') trees++;
            }
            Console.WriteLine("({0}, {1}): {2} trees encountered", dy, dx, trees);
            return trees;
        }
    }
}
