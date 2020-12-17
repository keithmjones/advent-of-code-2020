using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day17Test
    {
        [Theory]
        [InlineData(new string[] {
            ".#.",
            "..#",
            "###"
        }, 112)]
        public void CanSolvePart1(string[] data, int expected)
        {
            var day = new Day17();
            var result = day.Solve(data, 6, 1);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] {
            ".#.",
            "..#",
            "###"
        }, 848)]
        public void CanSolvePart2(string[] data, int expected)
        {
            var day = new Day17();
            var result = day.Solve(data, 6, 13);
            Assert.Equal(expected, result);
        }
    }
}
