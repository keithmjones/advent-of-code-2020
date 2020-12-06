using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day1Test
    {
        [Theory]
        [InlineData(new int[] {}, 0, 1, 0)]
        [InlineData(new int[] { 1, 2, 3, 6, 8 }, 0, 5, 0)]
        [InlineData(new int[] { 1, 2, 3, 6, 8 }, 2, 5, 6)]
        [InlineData(new int[] { 1, 2, 3, 6, 8 }, 3, 13, 48)]
        [InlineData(new int[] { 1721, 979, 366, 299, 675, 1456 }, 2, 2020, 514579)]
        [InlineData(new int[] { 1721, 979, 366, 299, 675, 1456 }, 3, 2020, 241861950)]
        public void CanSolve(int[] ints, int howManyIntsToSum, int requiredSum, int expected)
        {
            var day1 = new Day1();
            var result = day1.Solve(ints, howManyIntsToSum, requiredSum);
            Assert.Equal(expected, result);
        }
    }
}
