using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Tests
{
    [TestClass()]
    public class CheckPasswordTests
    {
        [TestMethod()]
        public void CorrectPassword_ReturnsTrue()
        {
            // Arange
            string Password = "Admin1!#";
            bool Expected = true;

            // Act
            bool Actual = CheckPassword.ValidatePassword(Password);

            // Assert
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod()]
        public void CountSymbols8_ReturnsTrue()
        {
            // Arange
            string Password = "Admi1111@";
            bool Expected = true;

            // Act
            bool Actual = CheckPassword.ValidatePassword(Password);

            // Assert
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod()]
        public void CountSymbolsFrom30_ReturnsFalse()
        {
            // Arange
            string Password = "Admin111Admin111Admin111###@!";
            bool Expected = true;
            // Act
            bool Actual = CheckPassword.ValidatePassword(Password);

            // Assert
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod()]
        public void Check_PasswordWithSpecSymbols_ReturnsFalse()
        {
            // Arange
            string Password = "Admi271223505#";
            bool Expected = true;

            // Act
            bool Actual = CheckPassword.ValidatePassword(Password);

            // Assert
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod()]
        public void Check_PassowordWithOutSpecSymbols_ReturnsTrue()
        {
            // Arange
            string Password = "Admi27022105";
            bool Expected = true;

            // Act
            bool Actual = CheckPassword.ValidatePassword(Password);

            // Assert
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod()]
        public void Check_PasswordWithBigLetter_ReturnsTrue()
        {
            // Arange
            string Password = "Admins394!";
            bool Expected = true;

            // Act
            bool Actual = CheckPassword.ValidatePassword(Password);

            // Assert
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod()]
        public void Check_PasswordWithoutBigLetter_ReturnsFalse()
        {
            // Arange
            string Password = "adminss394!";
            bool Expected = true;

            // Act
            bool Actual = CheckPassword.ValidatePassword(Password);

            // Assert
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod()]
        public void Check_PasswordWithSmallLetter_ReturnsTrue()
        {
            // Arange
            string Password = "ADMin2004#";
            bool Expected = true;

            // Act
            bool Actual = CheckPassword.ValidatePassword(Password);

            // Assert
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod()]
        public void Check_PasswordWithoutSmallLetter_ReturnsFalse()
        {
            // Arange
            string Password = "ADMI2004#";
            bool Expected = true;

            // Act
            bool Actual = CheckPassword.ValidatePassword(Password);

            // Assert
            Assert.AreEqual(Expected, Actual);
        }
    }
}