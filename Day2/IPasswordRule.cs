using System.Linq;

public interface IPasswordRule {
    bool IsValidPassword(string password);
}
