using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day5: Day
    {
        private List<int> input;

        public void ReadInputFile(string inputFile)
        {
            input = File.ReadAllLines(inputFile).Select(GetSeatNumber).ToList();
            input.Sort();
        }

        public int GetSeatNumber(string boardingPass) => Convert.ToInt32(boardingPass.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1'), 2);

        public int SolvePart1()
        {
            return SolvePart1(input);
        }

        public int SolvePart2()
        {
            return SolvePart2(input);
        }

        public int SolvePart1(List<int> seatNumbers)
        {
            return seatNumbers.Max();
        }

        public int SolvePart2(List<int> seatNumbers)
        {
            return seatNumbers.Where((seatNumber, index) => index > 0 && seatNumbers[index - 1] == seatNumbers[index] - 2).Single() - 1;
        }
    }
}