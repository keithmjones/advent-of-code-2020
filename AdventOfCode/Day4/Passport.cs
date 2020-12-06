namespace AdventOfCode
{
    public class Passport
    {
        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }
        public string CountryId { get; set; }

        public void AddLine(string line)
        {
            string[] fields = line.Split(' ');
            foreach (var field in fields)
            {
                string[] kv = field.Split(':', 2);
                switch(kv[0])
                {
                    case "byr":
                        BirthYear = kv[1];
                        break;
                    case "iyr":
                        IssueYear = kv[1];
                        break;
                    case "eyr":
                        ExpirationYear = kv[1];
                        break;
                    case "hgt":
                        Height = kv[1];
                        break;
                    case "hcl":
                        HairColor = kv[1];
                        break;
                    case "ecl":
                        EyeColor = kv[1];
                        break;
                    case "pid":
                        PassportId = kv[1];
                        break;
                    case "cid":
                        CountryId = kv[1];
                        break;
                }
            }
        }
    }
}
