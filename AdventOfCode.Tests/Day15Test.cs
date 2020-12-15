using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day15Test
    {
        [Theory]
        [InlineData(new string[] { "0,3,6" }, 436)]
        public void CanSolvePart1(string[] data, int expected)
        {
            var day = new Day15();
            var result = day.SolvePart1(data);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] { "0,3,6" }, 175594)]
        [InlineData(new string[] { "1,3,2" }, 2578)]
        [InlineData(new string[] { "2,1,3" }, 3544142)]
        [InlineData(new string[] { "1,2,3" }, 261214)]
        [InlineData(new string[] { "2,3,1" }, 6895259)]
        [InlineData(new string[] { "3,2,1" }, 18)]
        [InlineData(new string[] { "3,1,2" }, 362)]
        public void CanSolvePart2(string[] data, int expected)
        {
            var day = new Day15();
            var result = day.SolvePart2(data);
            Assert.Equal(expected, result);
        }
    }
}
