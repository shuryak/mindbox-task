namespace FigureTask.Domain.Abstractions;

public abstract class FigureCreator
{
    protected abstract IFigure Create();

    public double CalculateArea()
    {
        IFigure figure = Create();

        return figure.GetArea();
    }
}
