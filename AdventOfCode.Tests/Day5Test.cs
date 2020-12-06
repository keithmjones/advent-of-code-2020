using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day5Test
    {
        [Theory]
        [InlineData("FFFFFFFLLL", 0)]
        [InlineData("BBBBBBBRRR", 1023)]
        [InlineData("FBFBBFFRLR", 357)]
        [InlineData("BFFFBBFRRR", 567)]
        [InlineData("FFFBBBFRRR", 119)]
        [InlineData("BBFFBBFRLL", 820)]
        public void CanGetSeatNumber(string boardingPass, int expected)
        {
            var day5 = new Day5();
            var result = day5.GetSeatNumber(boardingPass);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] {
            "FFFFFFFLLL",
            "BBBBBBBRRR",
            "FBFBBFFRLR",
            "BFFFBBFRRR",
            "FFFBBBFRRR",
            "BBFFBBFRLL"
        }, 1023)]
        [InlineData(new string[] {
            "FBFBBFFRLR",
            "BFFFBBFRRR",
            "FFFBBBFRRR",
            "BBFFBBFRLL"
        }, 820)]
        public void CanSolvePart1(string[] boardingPasses, int expected)
        {
            var day5 = new Day5();
            var result = day5.SolvePart1(boardingPasses.Select(day5.GetSeatNumber).ToList());
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] {
            "FFFFFFFRLL",
            "FFFFFFFLLR",
            "FFFFFFFLLL",
            "FFFFFFFLRL"
        }, 3)]
        public void CanSolvePart2(string[] boardingPasses, int expected)
        {
            var day5 = new Day5();
            List<int> seatNumbers = boardingPasses.Select(day5.GetSeatNumber).ToList();
            seatNumbers.Sort();
            var result = day5.SolvePart2(seatNumbers);
            Assert.Equal(expected, result);
        }
    }
}
