public class PasswordWithRule {
    public IPasswordRule Rule { get; }
    public string Password { get; }

    public PasswordWithRule(IPasswordRule rule, string pass) => (Rule, Password) = (rule, pass);

    public bool IsValid() {
        return Rule.IsValidPassword(Password);
    }
}
