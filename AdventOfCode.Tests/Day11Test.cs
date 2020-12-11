using System;
using System.Linq;
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
        }, 37)]
        public void CanSolvePart1(string[] room, int expected)
        {
            var day = new Day11();
            var result = day.Solve(room.Select(str => str.ToCharArray()).ToArray(), false);
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
        }, 26)]
        public void CanSolvePart2(string[] room, int expected)
        {
            var day = new Day11();
            var result = day.Solve(room.Select(str => str.ToCharArray()).ToArray(), true);
            Assert.Equal(expected, result);
        }
    }
}
