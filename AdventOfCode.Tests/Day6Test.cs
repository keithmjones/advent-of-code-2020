using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day6Test
    {
        [Theory]
        [InlineData(0)]
        public void CanSolve(int expected)
        {
            var day6 = new Day6();
            var result = day6.Solve();
            Assert.Equal(expected, result);
        }
    }
}
