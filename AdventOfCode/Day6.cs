using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day6: Day
    {
        private IEnumerable<string> data;

        public void ReadInputFile(string inputFile)
        {
            data = File.ReadAllLines(inputFile);
        }

        public int SolvePart1() => SolvePart1(data.ToArray());

        public int SolvePart2() => SolvePart2(data.ToArray());

        public int SolvePart1(string[] input) => Arrays.Collate(input, " ").Select(CountUniqueCharsExcludingSpaces).Sum();

        public int SolvePart2(string[] input) => Arrays.Collate(input, " ").Select(CountCommonCharsInEachSequence).Sum();

        public int CountUniqueCharsExcludingSpaces(string value) => value.Where(chr => chr != ' ').Distinct().Count();

        public int CountCommonCharsInEachSequence(string value) => value.Split(' ').Aggregate(CharAggregator).Count();

        public string CharAggregator(string first, string next) => String.Concat(first.Intersect(next));
    }
}