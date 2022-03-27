using FigureTask.Domain;
using FigureTask.Figures;
using NUnit.Framework;

namespace FigureTask.Tests;

public class CircleTests
{
    [Test]
    public void Init_ZeroRadius_ShouldThrowArgumentException()
    {
        Assert.Catch<ArgumentException>(() =>
        {
            Circle circle = new Circle(-5);
        });
    }
    
    [Test]
    public void Init_NegativeRadius_ShouldThrowArgumentException()
    {
        Assert.Catch<ArgumentException>(() =>
        {
            Circle circle = new Circle(-5);
        });
    }

    [Test]
    public void Init_LessThanMinRadius_ShouldThrowArgumentException()
    {
        Assert.Catch<ArgumentException>(() =>
        {
            Circle circle = new Circle(Circle.MinRadius - Constants.CalculationAccuracy);
        });
    }

    [Test]
    public void GetArea_ShouldReturnArea()
    {
        const double radius = 5;
        Circle circle = new Circle(radius);

        const double expectedValue = Math.PI * radius * radius;
        
        Assert.Less(Math.Abs(circle.GetArea() - expectedValue), Constants.CalculationAccuracy);
    }
}
