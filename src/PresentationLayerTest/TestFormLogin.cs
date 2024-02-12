using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer;
using System;

namespace PresentationLayerTest
{
    [TestClass]
    public class TestFormLogin
    {
        
        [TestMethod]
        public void IsCustomerDataValid_CustomerExists_ReturnsTrue()
        {
           
            var formLogin = new FormLogin();
            var customerBusiness = new CustomerBusiness();
            bool isValid = formLogin.IsCustomerDataValid("bojan@gmail.com", "boki123");

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsCustomerDataValid_CustomerDoesNotExist_ReturnsFalse()
        {
            
            var formLogin = new FormLogin();
            var customerBusiness = new CustomerBusiness();
         
            bool isValid = formLogin.IsCustomerDataValid("nonexistent@example.com", "password");

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsValidData_ValidData_ReturnsTrue()
        {
            var formLogin = new FormLogin();
            formLogin.ChangePasswordChar();
            string validEmail = "bojan@gmail.com";
            string validPassword = "boki123";

            bool isValid = formLogin.IsValidData(validEmail, validPassword);

            Assert.IsTrue(isValid);
        }
        [TestMethod]
        public void IsValidData_EmptyEmail_ReturnsFalse()
        {
            var formLogin = new FormLogin();
            string emptyEmail = "";

            bool isValid = formLogin.IsValidData(emptyEmail, "password");

            Assert.IsFalse(isValid);
            Assert.AreEqual("Email address field must not be empty!", formLogin.ErrorMessage);
        }

        [TestMethod]
        public void IsValidData_EmptyPassword_ReturnsFalse()
        {
            
            var formLogin = new FormLogin();
            string emptyPassword = "";

            bool isValid = formLogin.IsValidData("test@example.com", emptyPassword);

            Assert.IsFalse(isValid);
            Assert.AreEqual("Password field must not be empty!", formLogin.ErrorMessage);
        }
    }
}
