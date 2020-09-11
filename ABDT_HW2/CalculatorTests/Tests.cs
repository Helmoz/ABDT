using ABDT_HW2;
using NUnit.Framework;

namespace CalculatorTests
{
    public class Tests
    {
        private static Calculator Calculator { get; set; }
        [SetUp]
        public void Setup()
        {
            Calculator = new Calculator();
        }
        
        [Test]
        public void TestGetDigitCapacity()
        {
            Assert.AreEqual(Calculator.GetDigitCapacity(1).Item2, 1);
            Assert.AreEqual(Calculator.GetDigitCapacity(100).Item2, 2);
            Assert.AreEqual(Calculator.GetDigitCapacity(2345234).Item2, 6);
        }
        
        [Test]
        public void TestGetDigit()
        {
            Assert.AreEqual(Calculator.GetDigit(2345234, 6, 3), 2);
        }
        
        [Test]
        public void TestCalculateNDigit()
        {
            Assert.AreEqual(Calculator.CalculateNDigit(1), 1);
            Assert.AreEqual(Calculator.CalculateNDigit(100), 5);
            Assert.AreEqual(Calculator.CalculateNDigit(2000), 0);
            Assert.AreEqual(Calculator.CalculateNDigit(2345456456456), 6);
        }
    }
}