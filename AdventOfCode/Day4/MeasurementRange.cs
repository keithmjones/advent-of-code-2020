namespace AdventOfCode
{
    public class MeasurementRange
    {
        public string Units { get; }
        public int Min { get; }
        public int Max { get; }

        public MeasurementRange(string units, int min, int max)
        {
            Units = units;
            Min = min;
            Max = max;
        }
    }
}
