namespace Service.Shapes.Strategy
{
    public class RectangleStrategy : IShapeStrategy
    {
        public string ShapeType => "Rektangel";
        public string[] ParameterPrompts => new[] { "Bredd", "Höjd" };

        public double CalculateArea(double[] p) => p[0] * p[1];
        public double CalculatePerimeter(double[] p) => 2 * (p[0] + p[1]);
    }
}
