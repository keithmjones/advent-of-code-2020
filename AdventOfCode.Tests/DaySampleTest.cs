using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class DaySampleTest
    {
        [Theory]
        [InlineData(new string[] {}, 0)]
        public void CanSolvePart1(string[] data, int expected)
        {
            var day = new DaySample();
            var result = day.SolvePart1(data);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] {}, 0)]
        public void CanSolvePart2(string[] data, int expected)
        {
            var day = new DaySample();
            var result = day.SolvePart2(data);
            Assert.Equal(expected, result);
        }
    }
}
