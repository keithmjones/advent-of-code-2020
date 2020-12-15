using System;
using System.Diagnostics;
using System.IO;
using AdventOfCode;

namespace CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayNumber = 0;
            string filename = "input";
            if (args.Length > 0)
            {
                Int32.TryParse(args[0], out dayNumber);
                if (args.Length > 1)
                {
                    filename = args[1];
                }
            }
            if (dayNumber < 1 || dayNumber > 25)
            {
                Console.Error.WriteLine("Day number must be between 1 and 25");
                Environment.Exit(1);
            }
            Day day = DayClass.NewDay(dayNumber);
            if (day == null) {
                Console.WriteLine("No solution found.");
                Environment.Exit(3);
            }
            string path = $"data/day/{dayNumber}/{filename}.txt";
            if (!File.Exists(path))
            {
                Console.Error.WriteLine("File '{0}' does not exist.", path);
                Environment.Exit(2);
            }
            else
            {
                day.ReadInputFile(path);
                SolvePart(1, day.SolvePart1);
                SolvePart(2, day.SolvePart2);
            }
        }

        static void SolvePart(int part, Func<Int64> partFn)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Int64 result = partFn();
            stopWatch.Stop();
            Console.WriteLine("Part {0}: {1} in {2} ms", part, result, stopWatch.ElapsedMilliseconds);
        }
    }
}
