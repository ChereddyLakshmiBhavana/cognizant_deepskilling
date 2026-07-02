// Required using statements for production type and NUnit APIs.
using CalcLibrary;
using NUnit.Framework;

// Group of tests for Calculator behaviors.
[TestFixture]
public class CalculatorTests
{
    // Shared test object initialized before each test.
    private Calculator _calculator = null!;

    // Runs before every test case to create a fresh Calculator instance.
    [SetUp]
    public void SetUp()
    {
        _calculator = new Calculator();
    }

    // Runs after every test case for any cleanup logic.
    [TearDown]
    public void TearDown()
    {
        _calculator = null!;
    }

    // Parameterized test cases validating Add with positive, negative, and zero values.
    [TestCase(2, 3, 5)]
    [TestCase(-1, 1, 0)]
    [TestCase(0, 0, 0)]
    [TestCase(-4, -6, -10)]
    [TestCase(100, 200, 300)]
    public void Add_ReturnsExpectedSum(int a, int b, int expected)
    {
        // Act: execute the method under test.
        int actual = _calculator.Add(a, b);

        // Assert: verify the result using NUnit's Assert.That syntax.
        Assert.That(actual, Is.EqualTo(expected));
    }
}