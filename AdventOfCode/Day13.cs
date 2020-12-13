using System;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day13: Day
    {
        private Int64 timestamp;
        private string[] data;

        public void ReadInputFile(string inputFile)
        {
            data = File.ReadAllLines(inputFile);
        }

        public Int64 SolvePart1() => SolvePart1(data);

        public Int64 SolvePart2() => SolvePart2(data);

        public Int64 WaitTime(Int64 timestamp, Int64 busNumber) => (busNumber - (timestamp % busNumber)) % busNumber;

        public Int64 SolvePart1(string[] timetable)
        {
            var timestamp = Int64.Parse(timetable[0]);
            var schedule = timetable[1].Split(",").Where(value => value != "x").Select(value => Int64.Parse(value)).ToArray();
            var nextBus = schedule.OrderBy(busNumber => WaitTime(timestamp, busNumber)).First();
            return nextBus * WaitTime(timestamp, nextBus);
        }

        public (Int64, Int64) FindNext((Int64, Int64) largest, (Int64, Int64) next)
        {
            var (largestValue, largestIndex) = largest;
            var (nextValue, nextIndex) = next;
            var diff = (largestValue + nextIndex - largestIndex) % nextValue;
            Int64 multiplier = 1;
            while (diff != 0)
            {
                multiplier++;
                diff += largestValue;
                diff %= nextValue;
            }
            return (largestValue * nextValue, largestValue * (nextValue - multiplier) + largestIndex);
        }

        public Int64 SolvePart2(string[] timetable)
        {
            var schedule = timetable[1].Split(",")
                .Select(value => value == "x" ? "0" : value)
                .Select(value => Int64.Parse(value))
                .ToArray();
            var result = schedule.Where(value => value != 0)
                .OrderBy(value => value)
                .Reverse()
                .Select(value => (value, (Int64) Array.IndexOf(schedule, value)));
            var (lcm, offset) = result.Aggregate((first, next) => FindNext(first, next));
            return lcm - offset;
        }
    }
}