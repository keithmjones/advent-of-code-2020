using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class ComplexPassportValidator: PassportValidator
    {
        private static MeasurementRange[] HEIGHT_RANGES = { new MeasurementRange("cm", 150, 193), new MeasurementRange("in", 59, 76) };

        private bool IsValidIntegerInRange(string value, int min, int max)
        {
            var intValue = 0;
            return value != null
                && int.TryParse(value, out intValue)
                && intValue >= min
                && intValue <= max;
        }

        private bool IsValidMeasurement(string value, MeasurementRange range) => value.EndsWith(range.Units) && IsValidIntegerInRange(value.Substring(0, value.Length - 2), range.Min, range.Max);

        private bool IsValidMeasurement(string value, MeasurementRange[] ranges) => value != null && ranges.Aggregate(false, (current, next) => current || IsValidMeasurement(value, next));

        private bool Matches(string value, string pattern) => value != null && Regex.Matches(value, pattern).Count != 0;

        public override bool IsValid(Passport passport)
        {
            return IsValidIntegerInRange(passport.BirthYear, 1920, 2002)
                && IsValidIntegerInRange(passport.IssueYear, 2010, 2020)
                && IsValidIntegerInRange(passport.ExpirationYear, 2020, 2030)
                && IsValidMeasurement(passport.Height, HEIGHT_RANGES)
                && Matches(passport.HairColor, @"^[#][0-9a-f]{6}$")
                && Matches(passport.EyeColor, @"^(amb|blu|brn|gry|grn|hzl|oth)$")
                && Matches(passport.PassportId, @"^[0-9]{9}$");
        }
    }
}
