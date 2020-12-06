using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public abstract class PassportValidator: IPassportValidator
    {
        public int Count { get; set; }

        public void Validate(Passport passport)
        {
            if (IsValid(passport)) Count++;
        }

        public abstract bool IsValid(Passport passport);
    }
}
