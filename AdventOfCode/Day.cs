using System;
using System.Reflection;

namespace AdventOfCode
{
    public interface Day
    {
        void ReadInputFile(string inputFile);
        int SolvePart1();
        int SolvePart2();
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
            ConstructorInfo ctor = type.GetConstructor(new Type[] {});
            if (ctor == null)
            {
                Console.Error.WriteLine("Day {1} does not have an accessible default constructor.", day);
                return null;
            }
            return (Day) ctor.Invoke(new object[] {});
        }
    }
}
