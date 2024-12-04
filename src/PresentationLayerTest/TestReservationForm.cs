using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer;
using System;

namespace PresentationLayerTest
{
    [TestClass]
    public class TestReservationForm
    {
        [TestMethod]
        public void IsValidData_ValidData_ReturnsTrue()
        {
            var reservationForm = new reservationUserControl();
            bool result = reservationForm.IsValidData("Section A", "4", DateTime.Now.AddDays(1));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidData_InvalidDate_ReturnsFalse()
        {
            var reservationForm = new reservationUserControl();
            bool result = reservationForm.IsValidData("Section A", "4", DateTime.Now.AddDays(-1));

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidData_InvalidNumberOfCustomers_ReturnsFalse()
        {
            var reservationForm = new reservationUserControl();
            bool result = reservationForm.IsValidData("Section A", "abc", DateTime.Now.AddDays(1));

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidData_EmptyFields_ReturnsFalse()
        {
            var reservationForm = new reservationUserControl();
            bool result = reservationForm.IsValidData("", "", DateTime.Now.AddDays(1));

            Assert.IsFalse(result);
        }
    }
}
