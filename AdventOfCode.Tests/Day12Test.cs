using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day12Test
    {
        [Theory]
        [InlineData(new string[] {
            "F10",
            "N3",
            "F7",
            "R90",
            "F11"
        }, 25)]
        public void CanSolvePart1(string[] data, int expected)
        {
            var day = new Day12();
            var result = day.SolvePart1(data);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] {
            "F10",
            "N3",
            "F7",
            "R90",
            "F11"
        }, 286)]
        public void CanSolvePart2(string[] data, int expected)
        {
            var day = new Day12();
            var result = day.SolvePart2(data);
            Assert.Equal(expected, result);
        }
    }
}
