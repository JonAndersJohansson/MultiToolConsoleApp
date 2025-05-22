namespace Service.Shapes.Strategy
{
    public interface IShapeStrategy
    {
        string ShapeType { get; }
        string[] ParameterPrompts { get; } // t.ex. ["Bredd", "Höjd"]
        double CalculateArea(double[] parameters);
        double CalculatePerimeter(double[] parameters);
    }
}
