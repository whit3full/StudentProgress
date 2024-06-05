using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckAuth.Tests
{
    [TestClass()]
    public class LoginCheckerTests
    {
        [TestMethod()]
        public void Check4Symbols_ReturnsTrue()
        {
            // Arrange
            string login = "Admi";
            bool expected = true;
            // Act
            bool actual = CheckLogin.ValidateLogin(login);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_LoginWithSpecSymbols_ReturnsFalse()
        {
            // Arrange
            string login = "Admi#";
            bool expected = false;

            // Act
            bool actual = CheckLogin.ValidateLogin(login);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_LoginWithOutSpecSymbols_ReturnsTrue()
        {
            // Arrange
            string login = "Admi";
            bool expected = true;

            // Act
            bool actual = CheckLogin.ValidateLogin(login);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}