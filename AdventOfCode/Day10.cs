using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day10: Day
    {
        private IEnumerable<Int64> input;

        public void ReadInputFile(string inputFile)
        {
            input = File.ReadAllLines(inputFile).Select(value => Int64.Parse(value));
        }

        public Int64 SolvePart1() => SolvePart1(input.ToArray());

        public Int64 SolvePart2() => SolvePart2(input.ToArray());

        Int64[] TopAndTail(IEnumerable<Int64> ints) {
            Int64[] array = ints.Prepend(0).Append(ints.Max() + 3).ToArray();
            Array.Sort(array);
            return array;
        }

        public Int64 SolvePart1(IEnumerable<Int64> ints)
        {
            var array = TopAndTail(ints);
            var ones = 0;
            var threes = 0;
            Int64 last = 0;
            foreach (var value in array)
            {
                var difference = value - last;
                if (difference == 1) ones++;
                if (difference == 3) threes++;
                last = value;
            }
            return ones * threes;
        }

        public Int64 SolvePart2(IEnumerable<Int64> ints)
        {
            var array = TopAndTail(ints);
            Int64 last = 0;
            var chain = 0;
            var thisChainPermutations = 1;
            Int64 totalPermutations = 1;
            foreach (var value in array)
            {
                var difference = value - last;
                if (difference == 1 || difference == 2)
                {
                    thisChainPermutations += chain;
                    chain++;
                }
                else if (chain != 0)
                {
                    totalPermutations *= thisChainPermutations;
                    chain = 0;
                    thisChainPermutations = 1;
                }
                last = value;
            }
            return totalPermutations;
        }
    }
}
