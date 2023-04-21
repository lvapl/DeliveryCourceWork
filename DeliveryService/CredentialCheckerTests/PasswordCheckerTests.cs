using CredentialChecker;
using CredentialChecker.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CredentialCheckerTests
{
    [TestClass]
    public class PasswordCheckerTests
    {        
        [TestMethod]
        public void Check_LessThan5Characters_ReturnsVeryWeak()
        {
            const string PASSWORD = "1";

            PasswordDifficulty actual = PasswordChecker.Check(PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.VeryWeak);
        }
        
        [TestMethod]
        public void Check_Digit5Characters_ReturnsWeak()
        {
            const string PASSWORD = "11111";

            PasswordDifficulty actual = PasswordChecker.Check(PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.Weak);
        }
        
        [TestMethod]
        public void Check_LowerCase5Characters_ReturnsWeak()
        {
            const string PASSWORD = "aaaaa";

            PasswordDifficulty actual = PasswordChecker.Check(PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.Weak);
        }
        
        [TestMethod]
        public void Check_UpperCase5Characters_ReturnsWeak()
        {
            const string PASSWORD = "AAAAA";

            PasswordDifficulty actual = PasswordChecker.Check(PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.Weak);
        }
        
        [TestMethod]
        public void Check_Symbol5Characters_ReturnsWeak()
        {
            const string PASSWORD = "+++++";

            PasswordDifficulty actual = PasswordChecker.Check(PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.Weak);
        }
        
        [TestMethod]
        public void Check_DigitAndLowerCaseCharacters_ReturnsNormal()
        {
            const string PASSWORD = "111aaa";

            PasswordDifficulty actual = PasswordChecker.Check(PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.Normal);
        }
        
        [TestMethod]
        public void Check_DigitAndUpperCaseCharacters_ReturnsNormal()
        {
            const string PASSWORD = "111AAA";

            PasswordDifficulty actual = PasswordChecker.Check(PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.Normal);
        }
        
        [TestMethod]
        public void Check_DigitAndSymbolCharacters_ReturnsNormal()
        {
            const string PASSWORD = "111+++";

            PasswordDifficulty actual = PasswordChecker.Check(PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.Normal);
        }
        
        [TestMethod]
        public void Check_LowerCaseAndUpperCaseCharacters_ReturnsNormal()
        {
            const string PASSWORD = "aaaAAA";

            PasswordDifficulty actual = PasswordChecker.Check(PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.Normal);
        }
        
        [TestMethod]
        public void Check_LowerCaseAndSymbolCharacters_ReturnsNormal()
        {
            const string PASSWORD = "aaa+++";

            PasswordDifficulty actual = PasswordChecker.Check(PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.Normal);
        }
        
        [TestMethod]
        public void Check_UpperCaseAndSymbolCharacters_ReturnsNormal()
        {
            const string PASSWORD = "AAA+++";

            PasswordDifficulty actual = PasswordChecker.Check(PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.Normal);
        }
        
        [TestMethod]
        public void Check_DigitAndLowerCaseAndUpperCaseCharacters_ReturnsStrong()
        {
            const string PASSWORD = "11aaAA";

            PasswordDifficulty actual = PasswordChecker.Check(PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.Strong);
        }
        
        [TestMethod]
        public void Check_LowerCaseAndUpperCaseAndSymbolCharacters_ReturnsStrong()
        {
            const string PASSWORD = "aaAA++";

            PasswordDifficulty actual = PasswordChecker.Check(PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.Strong);
        }

        [TestMethod]
        public void Check_UpperCaseAndSymbolAndDigitCharacters_ReturnsStrong()
        {
            const string PASSWORD = "AA++11";

            PasswordDifficulty actual = PasswordChecker.Check(PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.Strong);
        }

        [TestMethod]
        public void Check_SymbolAndDigitAndLowerCaseCharacters_ReturnsStrong()
        {
            const string PASSWORD = "++11aa";

            PasswordDifficulty actual = PasswordChecker.Check(PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.Strong);
        }

        [TestMethod]
        public void Check_DigitAndLowerCaseAndUpperCaseAndSymbolCharacters_ReturnsVeryStrong()
        {
            const string PASSWORD = "11aaAA++";

            PasswordDifficulty actual = PasswordChecker.Check(PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.VeryStrong);
        }

        [TestMethod]
        public void Check_Null_ReturnsVeryWeak()
        {
            const string? NULL_PASSWORD = null;

            PasswordDifficulty actual = PasswordChecker.Check(NULL_PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.VeryWeak);
        }

        [TestMethod]
        public void Check_EmptyString_ReturnsVeryWeak()
        {
            const string EMPTY_PASSWORD = "";

            PasswordDifficulty actual = PasswordChecker.Check(EMPTY_PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.VeryWeak);
        }

        [TestMethod]
        public void Check_SpaceCharacter_ReturnsVeryWeak()
        {
            const string SPACE_PASSWORD = " ";

            PasswordDifficulty actual = PasswordChecker.Check(SPACE_PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.VeryWeak);
        }
        
        [TestMethod]
        public void Check_Space5Characters_ReturnsVeryWeak()
        {
            const string SPACES_PASSWORD = "     ";

            PasswordDifficulty actual = PasswordChecker.Check(SPACES_PASSWORD);

            Assert.AreEqual(actual, PasswordDifficulty.VeryWeak);
        }
    }
}