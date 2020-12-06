using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day3Test
    {
        private string[] Map = {
            "..##.......",
            "#...#...#..",
            ".#....#..#.",
            "..#.#...#.#",
            ".#...##..#.",
            "..#.##.....",
            ".#.#.#....#",
            ".#........#",
            "#.##...#...",
            "#...##....#",
            ".#..#...#.#"
        };

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(1, 3, 7)]
        [InlineData(1, 5, 3)]
        [InlineData(1, 7, 4)]
        [InlineData(2, 1, 2)]
        public void CanCalculateNumberOfTreesEncountered(int dy, int dx, int expected)
        {
            var day3 = new Day3();
            var result = day3.CalculateNumberOfTreesEncountered(Map, dy, dx);
            Assert.Equal(expected, result);
        }
    }
}
