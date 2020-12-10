using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class DaySampleTest
    {
        [Theory]
        [InlineData(new Int64[] {}, 0)]
        public void CanSolvePart1(Int64[] ints, int expected)
        {
            var day = new DaySample();
            var result = day.SolvePart1(ints);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new Int64[] {}, 0)]
        public void CanSolvePart2(Int64[] ints, int expected)
        {
            var day = new DaySample();
            var result = day.SolvePart2(ints);
            Assert.Equal(expected, result);
        }
    }
}
