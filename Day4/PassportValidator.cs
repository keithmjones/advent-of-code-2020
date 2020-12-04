using System.Linq;
using System.Text.RegularExpressions;

public interface IPassportValidator {
    bool IsValid(Passport passport);
}

public abstract class PassportValidator: IPassportValidator {
    public int Count { get; set; }

    public void Validate(Passport passport) {
        if (IsValid(passport)) Count++;
    }

    public abstract bool IsValid(Passport passport);
}

public class SimplePassportValidator: PassportValidator {
    public override bool IsValid(Passport passport) {
        return passport.BirthYear != null
               && passport.IssueYear != null
               && passport.ExpirationYear != null
               && passport.Height != null
               && passport.HairColor != null
               && passport.EyeColor != null
               && passport.PassportId != null;
    }
}

public class MeasurementRange {
    public string Units { get; }
    public int Min { get; }
    public int Max { get; }
    public MeasurementRange(string units, int min, int max) { Units = units; Min = min; Max = max; }
}

public class ComplexPassportValidator: PassportValidator {
    private bool IsValidIntegerInRange(string value, int min, int max) {
        var intValue = 0;
        return value != null
               && int.TryParse(value, out intValue)
               && intValue >= min
               && intValue <= max;
    }

    private bool IsValidMeasurement(string value, MeasurementRange range) => value.EndsWith(range.Units) && IsValidIntegerInRange(value.Substring(0, value.Length - 2), range.Min, range.Max);

    private bool IsValidMeasurement(string value, MeasurementRange[] ranges) => value != null && ranges.Aggregate(false, (current, next) => current || IsValidMeasurement(value, next));

    private bool Matches(string value, string pattern) => value != null && Regex.Matches(value, pattern).Count != 0;

    private static MeasurementRange[] HEIGHT_RANGES = new MeasurementRange[] {
        new MeasurementRange("cm", 150, 193),
        new MeasurementRange("in", 59, 76)
    };

    public override bool IsValid(Passport passport) {

        return IsValidIntegerInRange(passport.BirthYear, 1920, 2002)
               && IsValidIntegerInRange(passport.IssueYear, 2010, 2020)
               && IsValidIntegerInRange(passport.ExpirationYear, 2020, 2030)
               && IsValidMeasurement(passport.Height, HEIGHT_RANGES)
               && Matches(passport.HairColor, @"^[#][0-9a-f]{6}$")
               && Matches(passport.EyeColor, @"^(amb|blu|brn|gry|grn|hzl|oth)$")
               && Matches(passport.PassportId, @"^[0-9]{9}$");
    }
}
