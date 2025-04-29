using Xunit;
using ArchitecturePatterns.TDD.Models;

namespace ArchitecturePatterns.TDD.Tests;

public class CalculatorTests
{
    [Fact]
    public void Add_ShouldReturnSumOfTwoNumbers()
    {
        var calculator = new Calculator();
        var result = calculator.Add(2, 3);
        Assert.Equal(5, result);
    }

    [Fact]
    public void Subtract_ShouldReturnDifferenceOfTwoNumbers()
    {
        var calculator = new Calculator();
        var result = calculator.Subtract(5, 2);
        Assert.Equal(3, result);
    }

    [Fact]
    public void Multiply_ShouldReturnProductOfTwoNumbers()
    {
        var calculator = new Calculator();
        var result = calculator.Multiply(4, 3);
        Assert.Equal(12, result);
    }

    [Fact]
    public void Divide_ShouldReturnQuotientOfTwoNumbers()
    {
        var calculator = new Calculator();
        var result = calculator.Divide(10, 2);
        Assert.Equal(5, result);
    }

    [Fact]
    public void Divide_ByZero_ShouldThrowException()
    {
        var calculator = new Calculator();
        Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
    }
}