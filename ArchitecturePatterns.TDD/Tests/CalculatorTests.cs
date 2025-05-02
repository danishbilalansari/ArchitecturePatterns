using Xunit;
using ArchitecturePatterns.TDD.Models;

namespace ArchitecturePatterns.TDD.Tests
{
    /// <summary>
    /// Contains unit tests for the <see cref="Calculator"/> class.
    /// These tests ensure that the Calculator class methods function correctly for basic arithmetic operations.
    /// </summary>
    public class CalculatorTests
    {
        /// <summary>
        /// Tests that the <see cref="Calculator.Add"/> method returns the correct sum of two numbers.
        /// </summary>
        [Fact]
        public void Add_ShouldReturnSumOfTwoNumbers()
        {
            var calculator = new Calculator();
            var result = calculator.Add(2, 3);
            Assert.Equal(5, result);
        }

        /// <summary>
        /// Tests that the <see cref="Calculator.Subtract"/> method returns the correct difference when subtracting two numbers.
        /// </summary>
        [Fact]
        public void Subtract_ShouldReturnDifferenceOfTwoNumbers()
        {
            var calculator = new Calculator();
            var result = calculator.Subtract(5, 2);
            Assert.Equal(3, result);
        }

        /// <summary>
        /// Tests that the <see cref="Calculator.Multiply"/> method returns the correct product of two numbers.
        /// </summary>
        [Fact]
        public void Multiply_ShouldReturnProductOfTwoNumbers()
        {
            var calculator = new Calculator();
            var result = calculator.Multiply(4, 3);
            Assert.Equal(12, result);
        }

        /// <summary>
        /// Tests that the <see cref="Calculator.Divide"/> method returns the correct quotient when dividing two numbers.
        /// </summary>
        [Fact]
        public void Divide_ShouldReturnQuotientOfTwoNumbers()
        {
            var calculator = new Calculator();
            var result = calculator.Divide(10, 2);
            Assert.Equal(5, result);
        }

        /// <summary>
        /// Tests that the <see cref="Calculator.Divide"/> method throws a <see cref="DivideByZeroException"/>
        /// when attempting to divide by zero.
        /// </summary>
        [Fact]
        public void Divide_ByZero_ShouldThrowException()
        {
            var calculator = new Calculator();
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
        }
    }
}
