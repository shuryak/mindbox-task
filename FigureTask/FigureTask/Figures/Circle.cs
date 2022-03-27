using FigureTask.Domain;
using FigureTask.Domain.Abstractions;

namespace FigureTask.Figures;

public class Circle : IFigure
{
    // An order of magnitude larger because formula uses squaring
    /// <summary>
    /// Minimum allowable radius
    /// </summary>
    public const double MinRadius = Constants.CalculationAccuracy * 10;
    
    /// <param name="radius">Radius of circle</param>
    /// <exception cref="ArgumentException"></exception>
    public Circle(double radius)
    {
        if (radius - MinRadius < Constants.CalculationAccuracy)
            throw new ArgumentException("Invalid radius");
        
        Radius = radius;
    }

    public double Radius { get; }
    
    /// <summary>
    /// Calculate area of circle
    /// </summary>
    /// <returns>Area of circle</returns>
    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}
