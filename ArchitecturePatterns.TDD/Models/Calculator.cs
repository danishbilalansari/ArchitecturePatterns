namespace ArchitecturePatterns.TDD.Models
{
    /// <summary>
    /// Provides basic arithmetic operations.
    /// This class includes methods for addition, subtraction, multiplication, and division.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Adds two integers together.
        /// </summary>
        /// <param name="a">The first integer to add.</param>
        /// <param name="b">The second integer to add.</param>
        /// <returns>The sum of the two integers.</returns>
        public int Add(int a, int b) => a + b;

        /// <summary>
        /// Subtracts the second integer from the first.
        /// </summary>
        /// <param name="a">The integer to subtract from.</param>
        /// <param name="b">The integer to subtract.</param>
        /// <returns>The difference between the two integers.</returns>
        public int Subtract(int a, int b) => a - b;

        /// <summary>
        /// Multiplies two integers together.
        /// </summary>
        /// <param name="a">The first integer to multiply.</param>
        /// <param name="b">The second integer to multiply.</param>
        /// <returns>The product of the two integers.</returns>
        public int Multiply(int a, int b) => a * b;

        /// <summary>
        /// Divides the first integer by the second.
        /// Throws a <see cref="DivideByZeroException"/> if the second integer is zero.
        /// </summary>
        /// <param name="a">The integer to divide.</param>
        /// <param name="b">The integer to divide by.</param>
        /// <returns>The quotient of the division.</returns>
        /// <exception cref="DivideByZeroException">Thrown when attempting to divide by zero.</exception>
        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }

            return a / b;
        }
    }
}
