using FigureTask.Domain;
using FigureTask.Figures;
using NUnit.Framework;

namespace FigureTask.Tests;

public class TriangleTests
{
    [TestCase(1, 1, -1)]
    [TestCase(1, -1, 1)]
    [TestCase(-1, 1, 1)]
    [TestCase(1, 1, 0)]
    [TestCase(1, 0, 1)]
    [TestCase(0, 1, 1)]
    public void Init_BadEdges_ShouldThrowArgumentException(double a, double b, double c)
    {
        Assert.Catch<ArgumentException>(() =>
        {
            Triangle triangle = new Triangle(a, b, c);
        });
    }

    [Test]
    public void Init_NotTriangle_ShouldThrowArgumentException()
    {
        Assert.Catch<ArgumentException>(() =>
        {
            Triangle triangle = new Triangle(1, 1, 3);
        });
    }
    
    [Test]
    public void GetArea_DifferentEdges_ShouldReturnArea()
    {
        // Arrange
        double a = 8, b = 5, c = 5;
        double expectedResult = 12;

        Triangle triangle = new Triangle(a, b, c);
        
        // Act
        double area = triangle.GetArea();

        // Assert
        Assert.IsFalse(triangle.IsRight);
        Assert.Less(Math.Abs(area - expectedResult), Constants.CalculationAccuracy);
    }
    
    [Test]
    public void GetArea_RightTriangle_ShouldReturnArea()
    {
        // Arrange
        double a = 3, b = 4, c = 5;
        double expectedResult = 6;

        Triangle triangle = new Triangle(a, b, c);
        
        // Act
        double area = triangle.GetArea();

        // Assert
        Assert.IsTrue(triangle.IsRight);
        Assert.Less(Math.Abs(area - expectedResult), Constants.CalculationAccuracy);
    }
}
