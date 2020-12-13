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

        public (Int64, Int64) FindNext(Int64[] schedule, Int64 largest, Int64 next, Int64 largestIndex)
        {
            var nextIndex = Array.IndexOf(schedule, next);
            var indexDiff = largestIndex - nextIndex;
            var diff = (largest - indexDiff) % next;
            Int64 multiplier = 1;
            while (diff != 0)
            {
                multiplier++;
                diff += largest;
                diff %= next;
            }
            Int64 multiple = largest * next;
            Int64 time = multiplier * largest;
            Console.WriteLine("Largest {0} (t+{1}) Next {2} (t+{3}) x={0} m={1} t={2}",
                            largest, largestIndex, next, nextIndex, multiplier, multiple, time);
            Console.WriteLine("Large: {0} x {1} - {2} = {3}", largest, multiplier, largestIndex, largest * multiplier - largestIndex);
            Int64 nlm = (time + nextIndex) / next;
            Console.WriteLine("Next:  {0} x {1} - {2} = {3}", next, nlm, nextIndex, next * nlm - nextIndex);
            return (multiple, (multiple - time) + largestIndex);
        }

        public Int64 SolvePart2(string[] timetable)
        {
            var schedule = timetable[1].Split(",").Select(value => value == "x" ? "0" : value).Select(value => Int64.Parse(value)).ToArray();
            var orderedSchedule = schedule.Where(value => value != 0).OrderBy(value => value).Reverse().ToArray();
            // Find the two largest
            var largest = orderedSchedule[0];
            var largestIndex = (Int64) Array.IndexOf(schedule, largest);
            foreach (var nextLargest in orderedSchedule)
            {
                if (nextLargest != largest)
                {
                    (largest, largestIndex) = FindNext(schedule, largest, nextLargest, largestIndex);
                }
            }
            return largest - largestIndex;
        }
    }
}