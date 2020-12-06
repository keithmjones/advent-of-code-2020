using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class PasswordWithRule
    {
        public IPasswordRule Rule { get; }
        public string Password { get; }

        public PasswordWithRule(IPasswordRule rule, string pass) => (Rule, Password) = (rule, pass);

        public bool IsValid()
        {
            return Rule.IsValidPassword(Password);
        }

        public static PasswordWithRule Parse<TRule>(string line) where TRule : IPasswordRule
        {
            // Parse arguments
            Regex rx = new Regex(@"(\d+)[-](\d+) (.)[:] (.+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            GroupCollection groups = rx.Matches(line)[0].Groups;
            int first = int.Parse(groups[1].Value);
            int second = int.Parse(groups[2].Value);
            char chr = groups[3].Value[0];
            string pass = groups[4].Value;

            // Turn into a PasswordWithRule
            Type ruleType = typeof(TRule);
            ConstructorInfo ctor = ruleType.GetConstructor(new[] { typeof(int), typeof(int), typeof(char) });
            IPasswordRule rule = (IPasswordRule) ctor.Invoke(new object[] { first, second, chr });
            return new PasswordWithRule(rule, pass);
        }
    }
}
