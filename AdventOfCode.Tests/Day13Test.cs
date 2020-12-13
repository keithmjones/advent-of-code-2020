using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day13Test
    {
        [Theory]
        [InlineData(new string[] {
            "939",
            "7,13,x,x,59,x,31,19"
        }, 295)]
        public void CanSolvePart1(string[] data, int expected)
        {
            var day = new Day13();
            var result = day.SolvePart1(data);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] {
            "939",
            "2,3,5"
        }, 8)]
        [InlineData(new string[] {
            "939",
            "2,5,3"
        }, 4)]
        [InlineData(new string[] {
            "939",
            "2,x,3,5"
        }, 22)]
        [InlineData(new string[] {
            "939",
            "7,13,x,x,59,x,31,19"
        }, 1068781)]
        [InlineData(new string[] {
            "939",
            "17,x,13,19"
        }, 3417)]
        [InlineData(new string[] {
            "939",
            "67,7,59,61"
        }, 754018)]
        [InlineData(new string[] {
            "939",
            "67,x,7,59,61"
        }, 779210)]
        [InlineData(new string[] {
            "939",
            "67,7,x,59,61"
        }, 1261476)]
        [InlineData(new string[] {
            "939",
            "1789,37,47,1889"
        }, 1202161486)]
        public void CanSolvePart2(string[] data, int expected)
        {
            var day = new Day13();
            var result = day.SolvePart2(data);
            Assert.Equal(expected, result);
        }
    }
}
