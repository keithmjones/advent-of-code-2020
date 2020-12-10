using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day10Test
    {
        [Theory]
        [InlineData(
            new Int64[]
            {
                16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4
            }, 35)]
        [InlineData(
            new Int64[]
            {
                28, 33, 18, 42, 31, 14, 46, 20, 48, 47, 24, 23,
                49, 45, 19, 38, 39, 11, 1, 32, 25, 35, 8, 17,
                7, 9, 4, 2, 34, 10, 3
            }, 220)]
        public void CanSolvePart1(Int64[] ints, int expected)
        {
            var day10 = new Day10();
            var result = day10.SolvePart1(ints);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(
            new Int64[]
            {
                16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4
            }, 0)]
        public void CanSolvePart2(Int64[] ints, int expected)
        {
            var day10 = new Day10();
            var result = day10.SolvePart2(ints);
            Assert.Equal(expected, result);
        }
    }
}
