using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day1Test
    {
        [Theory]
        [InlineData(new Int64[] {}, 0, 1, 0)]
        [InlineData(new Int64[] { 1, 2, 3, 6, 8 }, 0, 5, 0)]
        [InlineData(new Int64[] { 1, 2, 3, 6, 8 }, 2, 5, 6)]
        [InlineData(new Int64[] { 1, 2, 3, 6, 8 }, 3, 13, 48)]
        [InlineData(new Int64[] { 1721, 979, 366, 299, 675, 1456 }, 2, 2020, 514579)]
        [InlineData(new Int64[] { 1721, 979, 366, 299, 675, 1456 }, 3, 2020, 241861950)]
        public void CanFindNumbersWithSum(Int64[] ints, int howManyIntsToSum, int requiredSum, int expected)
        {
            var result = FindNumbersWithSum.Find(ints, howManyIntsToSum, requiredSum);
            Assert.Equal(expected, result);
        }
    }
}
