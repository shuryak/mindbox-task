using FigureTask.Domain;
using FigureTask.Domain.Abstractions;

namespace FigureTask.Figures;

public class Triangle : ITriangle
{
    public double EdgeA { get; }
    
    public double EdgeB { get; }
    
    public double EdgeC { get; }
    
    private readonly Lazy<bool> _isRight;

    public bool IsRight => _isRight.Value;
    
    /// <param name="edgeA">Edge A of triangle</param>
    /// <param name="edgeB">Edge B of triangle</param>
    /// <param name="edgeC">Edge C of triangle</param>
    /// <exception cref="ArgumentException"></exception>
    public Triangle(double edgeA, double edgeB, double edgeC)
    {
        if (edgeA < Constants.CalculationAccuracy)
            throw new ArgumentException("Invalid edge", nameof(edgeA));
        if (edgeB < Constants.CalculationAccuracy)
            throw new ArgumentException("Invalid edge", nameof(edgeB));
        if (edgeC < Constants.CalculationAccuracy)
            throw new ArgumentException("Invalid edge", nameof(edgeC));
        
        double maxEdge = Math.Max(edgeA, Math.Max(edgeB, edgeC));
        double perimeter = (edgeA + edgeB + edgeC);
        
        if (perimeter - 2 * maxEdge < Constants.CalculationAccuracy)
            throw new ArgumentException(
                "The longest side of the triangle must be less than the sum of the other two sides");
        
        EdgeA = edgeA;
        EdgeB = edgeB;
        EdgeC = edgeC;

        _isRight = new Lazy<bool>(GetIsRight);
    }

    private bool GetIsRight()
    {
        double maxEdge = EdgeA, edgeB = EdgeB, edgeC = EdgeC;
        if (edgeB - maxEdge > Constants.CalculationAccuracy)
        {
            edgeB = maxEdge;
            maxEdge = EdgeB;
        }
        if (edgeC - maxEdge > Constants.CalculationAccuracy)
        {
            edgeC = maxEdge;
            maxEdge = EdgeC;
        }

        return Math.Abs(Math.Pow(maxEdge, 2) - Math.Pow(edgeB, 2) - Math.Pow(edgeC, 2)) < Constants.CalculationAccuracy;
    }
    
    /// <summary>
    /// Calculate area of triangle
    /// </summary>
    /// <returns>Area of triangle</returns>
    public double GetArea()
    {
        double semiPerimeter = (EdgeA + EdgeB + EdgeC) / 2;
        double area = Math.Sqrt(semiPerimeter * (semiPerimeter - EdgeA) * (semiPerimeter - EdgeB) *
                                (semiPerimeter - EdgeC));

        return area;
    }
}
