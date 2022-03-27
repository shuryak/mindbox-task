namespace FigureTask.Domain.Abstractions;

public interface ITriangle : IFigure
{
    double EdgeA { get; }
    
    double EdgeB { get; }
    
    double EdgeC { get; }
    
    bool IsRight { get; }
}
