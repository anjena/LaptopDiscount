using NUnit.Framework;
using LaptopDiscount;
using System;

namespace LaptopDiscount.nUnitTests
{
    public class EmployeeDiscountTests
    {
        // Test setup
        private EmployeeDiscount _employeeDiscount;

        [SetUp]
        public void Setup()
        {
            _employeeDiscount = new EmployeeDiscount();
        }

        // Test for PartTime employee (No Discount)
        [TestCase(300)]
        [TestCase(500)]
        [TestCase(1000)]
        public void CalculateDiscountedPrice_PartTimeEmployee_ReturnsOriginalPrice(decimal price)
        {
            // Arrange
            _employeeDiscount.EmployeeType = EmployeeType.PartTime;
            _employeeDiscount.Price = price;

            // Act
            var actual = _employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.That(actual, Is.EqualTo(price), "Part-Time employees should receive no discount.");
        }

        // Test for PartialLoad employee (5% Discount)
        [TestCase(300, 285)]
        [TestCase(500, 475)]
        [TestCase(1000, 950)]
        public void CalculateDiscountedPrice_PartialLoadEmployee_ReturnsDiscountedPrice(decimal price, decimal expected)
        {
            // Arrange
            _employeeDiscount.EmployeeType = EmployeeType.PartialLoad;
            _employeeDiscount.Price = price;

            // Act
            var actual = _employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.That(actual, Is.EqualTo(expected), "Partial-Load employees should receive a 5% discount.");
        }

        // Test for FullTime employee (10% Discount)
        [TestCase(300, 270)]
        [TestCase(500, 450)]
        [TestCase(1000, 900)]
        public void CalculateDiscountedPrice_FullTimeEmployee_ReturnsDiscountedPrice(decimal price, decimal expected)
        {
            // Arrange
            _employeeDiscount.EmployeeType = EmployeeType.FullTime;
            _employeeDiscount.Price = price;

            // Act
            var actual = _employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.That(actual, Is.EqualTo(expected), "Full-Time employees should receive a 10% discount.");
        }

        // Test for CompanyPurchasing employee (20% Discount)
        [TestCase(300, 240)]
        [TestCase(500, 400)]
        [TestCase(1000, 800)]
        public void CalculateDiscountedPrice_CompanyPurchasingEmployee_ReturnsDiscountedPrice(decimal price, decimal expected)
        {
            // Arrange
            _employeeDiscount.EmployeeType = EmployeeType.CompanyPurchasing;
            _employeeDiscount.Price = price;

            // Act
            var actual = _employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.That(actual, Is.EqualTo(expected), "Company Purchasing should receive a 20% discount.");
        }

        // Test for negative price input
        [Test]
        public void CalculateDiscountedPrice_NegativePrice_ThrowsArgumentException()
        {
            // Arrange
            _employeeDiscount.EmployeeType = EmployeeType.PartTime;
            _employeeDiscount.Price = -100;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _employeeDiscount.CalculateDiscountedPrice(), "Price should not be negative.");
        }

        // Test for zero price input
        [Test]
        public void CalculateDiscountedPrice_ZeroPrice_ReturnsZero()
        {
            // Arrange
            _employeeDiscount.EmployeeType = EmployeeType.PartTime;
            _employeeDiscount.Price = 0;

            // Act
            var actual = _employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.That(actual, Is.EqualTo(0), "Discounted price should be 0 when the original price is 0.");
        }
    }
}
