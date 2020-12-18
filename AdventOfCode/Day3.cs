using System;
using System.IO;

namespace AdventOfCode
{
    public class Day3: Day
    {
        private string[] map;

        public void ReadInputFile(string inputFile)
        {
            // Get the map from the input file
            map = File.ReadAllLines(inputFile);
        }

        public Int64 SolvePart1()
        {
            // Calculate number of trees encountered with slope of Down 1, Right 3
            return CalculateNumberOfTreesEncountered(map, 1, 3);
        }

        public Int64 SolvePart2()
        {
            // Calculate product of number of trees encountered with different slopes
            var trees1x1 = CalculateNumberOfTreesEncountered(map, 1, 1);
            var trees1x3 = CalculateNumberOfTreesEncountered(map, 1, 3);
            var trees1x5 = CalculateNumberOfTreesEncountered(map, 1, 5);
            var trees1x7 = CalculateNumberOfTreesEncountered(map, 1, 7);
            var trees2x1 = CalculateNumberOfTreesEncountered(map, 2, 1);
            return trees1x1 * trees1x3 * trees1x5 * trees1x7 * trees2x1;
        }

        public int CalculateNumberOfTreesEncountered(string[] map, int dy, int dx)
        {
            var trees = 0;
            for (var line = dy; line < map.Length; line += dy)
            {
                if (map[line][(dx * line / dy) % map[line].Length] == '#') trees++;
            }
            return trees;
        }
    }
}
