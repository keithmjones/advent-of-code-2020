using System.Linq;

public class PositionCharsPasswordRule: IPasswordRule {
    public int FirstPosition { get; }
    public int SecondPosition { get; }
    public char CharToTest { get; }

    public PositionCharsPasswordRule(int first, int second, char chr) => (FirstPosition, SecondPosition, CharToTest) = (first, second, chr);

    public bool IsValidPassword(string password) {
        return ((password[FirstPosition - 1] == CharToTest) ^ (password[SecondPosition - 1] == CharToTest));
    }

    public override string ToString() {
        return $"{FirstPosition}-{SecondPosition} {CharToTest}";
    }
}
