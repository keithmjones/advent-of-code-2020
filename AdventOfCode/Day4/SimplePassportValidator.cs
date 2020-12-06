namespace AdventOfCode
{
    public class SimplePassportValidator: PassportValidator
    {
        public override bool IsValid(Passport passport)
        {
            return passport.BirthYear != null
                && passport.IssueYear != null
                && passport.ExpirationYear != null
                && passport.Height != null
                && passport.HairColor != null
                && passport.EyeColor != null
                && passport.PassportId != null;
        }
    }
}
