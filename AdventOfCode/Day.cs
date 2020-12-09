using System;

namespace AdventOfCode
{
    public interface Day
    {
        void ReadInputFile(string inputFile);
        Int64 SolvePart1();
        Int64 SolvePart2();
    }

    public class DayClass
    {
        public static Day NewDay(int day)
        {
            string className = $"AdventOfCode.Day{day}";
            Type type = Type.GetType(className);
            if (type == null)
            {
                Console.Error.WriteLine("Day {0} has not been implemented yet.", day);
                return null;
            }
            return (Day) Activator.CreateInstance(type);
        }
    }
}
