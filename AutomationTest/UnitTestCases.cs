using Xunit;

namespace AutomationTest
{
    public class UnitTestCases
    {
        [Fact]
        public void CalculatorUnitTest()
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            //var actual = calculator.Add(2, 2);

            // Assert
            //Assert.Equal(4, actual);
        }


        [Theory]
        [InlineData(1, 2)]
        [InlineData(5, 2)]
        [InlineData(5, 2.5)]
        public void TheoryTest(int a, int b)
        {
            Assert.NotEqual(a, b);
        }
    }
}
