using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayerTest
{
    [TestClass]
    public class TestFormRegister
    {
        [TestMethod]
        public void IsNameValid_ValidName_ReturnsTrue()
        {
            FormRegister formRegister = new FormRegister();

            bool result = formRegister.IsNameValid("Marko");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNameValid_NullOrWhiteSpaceName_ReturnsFalse()
        {
            FormRegister formRegister = new FormRegister();

            bool result = formRegister.IsNameValid(null);

            Assert.IsFalse(result);
            Assert.AreEqual("Name field must be filled in!", formRegister.ErrorMessage);
        }

        [TestMethod]
        public void IsNameValid_NameExceedsMaxLength_ReturnsFalse()
        {
            FormRegister formRegister = new FormRegister();

            bool result = formRegister.IsNameValid("OvoJePrimerDugackogImena");

            Assert.IsFalse(result);
            Assert.AreEqual("Name field must have 15 characters or less!", formRegister.ErrorMessage);
        }

        [TestMethod]
        public void IsNameValid_NameContainsNonLetters_ReturnsFalse()
        {
            FormRegister formRegister = new FormRegister();

            bool result = formRegister.IsNameValid("Marko123");

            Assert.IsFalse(result);
            Assert.AreEqual("Name must contain only characters!", formRegister.ErrorMessage);
        }

        [TestMethod]
        public void IsEmailValid_ValidEmail_ReturnsTrue()
        {
            FormRegister formRegister = new FormRegister();

            bool result = formRegister.IsEmailValid("marko@gmail.com");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEmailValid_InvalidEmail_ReturnsFalse()
        {
            FormRegister formRegister = new FormRegister();

            bool result = formRegister.IsEmailValid("email-adresa");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsPhoneValid_ValidPhone_ReturnsTrue()
        {
            FormRegister formRegister = new FormRegister();

            bool result = formRegister.IsPhoneValid("0641234567");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPhoneValid_InvalidCharacters_ReturnsFalse()
        {
            FormRegister formRegister = new FormRegister();

            bool result = formRegister.IsPhoneValid("invalidPhone");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsPasswordValid_ValidPassword_ReturnsTrue()
        {
            FormRegister formRegister = new FormRegister();
            formRegister.ChangePasswordChar();

            bool result = formRegister.IsPasswordValid("password123");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPasswordValid_TooShort_ReturnsFalse()
        {
            FormRegister formRegister = new FormRegister();

            bool result = formRegister.IsPasswordValid("pass");

            Assert.IsFalse(result);
            Assert.AreEqual("Password must have 6 or more characters!", formRegister.ErrorMessage);
        }

        [TestMethod]
        public void IsPasswordValid_TooLong_ReturnsFalse()
        {
            FormRegister formRegister = new FormRegister();

            bool result = formRegister.IsPasswordValid("password123password123456");

            Assert.IsFalse(result);
            Assert.AreEqual("Password must have less than 20 characters!", formRegister.ErrorMessage);
        }
    }
}
