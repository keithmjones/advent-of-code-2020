using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day15Test
    {
        [Theory]
        [InlineData(new string[] { "0,3,6" }, 2020, 436)]
        [InlineData(new string[] { "0,3,6" }, 30000000, 175594)]
        [InlineData(new string[] { "1,3,2" }, 30000000, 2578)]
        [InlineData(new string[] { "2,1,3" }, 30000000, 3544142)]
        [InlineData(new string[] { "1,2,3" }, 30000000, 261214)]
        [InlineData(new string[] { "2,3,1" }, 30000000, 6895259)]
        [InlineData(new string[] { "3,2,1" }, 30000000, 18)]
        [InlineData(new string[] { "3,1,2" }, 30000000, 362)]
        public void CanSolve(string[] data, int count, int expected)
        {
            var day = new Day15();
            var result = day.Solve(data, count);
            Assert.Equal(expected, result);
        }
    }
}
