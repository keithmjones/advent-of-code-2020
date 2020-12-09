using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day9Test
    {
        [Theory]
        [InlineData(
            new Int64[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
                15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26
            }, 25, -1)]
        [InlineData(
            new Int64[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
                15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 49
            }, 25, -1)]
        [InlineData(
            new Int64[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
                15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 100
            }, 25, 100)]
        [InlineData(
            new Int64[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
                15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 50
            }, 25, 50)]
        [InlineData(
            new Int64[]
            {
                35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102,
                117, 150, 182, 127, 219, 299, 277, 309, 576
            }, 5, 127)]
        public void CanSolvePart1(Int64[] ints, int preambleCount, int expected)
        {
            var day9 = new Day9();
            var result = day9.SolvePart1(ints, preambleCount);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(
            new Int64[]
            {
                35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102,
                117, 150, 182, 127, 219, 299, 277, 309, 576
            }, 5, 62)]
        public void CanSolvePart2(Int64[] ints, int preambleCount, int expected)
        {
            var day9 = new Day9();
            var result = day9.SolvePart2(ints, preambleCount);
            Assert.Equal(expected, result);
        }
    }
}
