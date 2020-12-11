using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day11Test
    {
        [Theory]
        [InlineData(new string[] {
            "L.LL.LL.LL",
            "LLLLLLL.LL",
            "L.L.L..L..",
            "LLLL.LL.LL",
            "L.LL.LL.LL",
            "L.LLLLL.LL",
            "..L.L.....",
            "LLLLLLLLLL",
            "L.LLLLLL.L",
            "L.LLLLL.LL"
        }, 0)]
        public void CanSolvePart1(string[] room, int expected)
        {
            var day = new Day11();
            var result = day.SolvePart1(room);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] {
            "L.LL.LL.LL",
            "LLLLLLL.LL",
            "L.L.L..L..",
            "LLLL.LL.LL",
            "L.LL.LL.LL",
            "L.LLLLL.LL",
            "..L.L.....",
            "LLLLLLLLLL",
            "L.LLLLLL.L",
            "L.LLLLL.LL"
        }, 0)]
        public void CanSolvePart2(string[] room, int expected)
        {
            var day = new Day11();
            var result = day.SolvePart2(room);
            Assert.Equal(expected, result);
        }
    }
}
