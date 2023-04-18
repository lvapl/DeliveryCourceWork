using CredentialChecker.Enums;

namespace CredentialChecker
{
    public class PasswordChecker
    {
        public static PasswordDifficulty Check(string? password)
        {
            PasswordDifficulty difficulty = PasswordDifficulty.VeryWeak;

            if (password == null || password.Length < 5)
            {
                return difficulty;
            }
            else
            {
                if (password.Any(char.IsDigit))
                {
                    difficulty++;
                }
                
                if (password.Any(char.IsLower))
                {
                    difficulty++;
                }
                
                if (password.Any(char.IsUpper))
                {
                    difficulty++;
                }

                if (password.Any(char.IsSymbol))
                {
                    difficulty++;
                }

                return difficulty;
            }
        }
    }
}