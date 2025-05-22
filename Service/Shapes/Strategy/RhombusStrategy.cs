namespace Service.Shapes.Strategy
{
    public class RhombusStrategy : IShapeStrategy
    {
        public string ShapeType => "Romb";
        public string[] ParameterPrompts => new[] { "Diagonal 1", "Diagonal 2", "Sida" };

        public double CalculateArea(double[] p) => (p[0] * p[1]) / 2;
        public double CalculatePerimeter(double[] p) => 4 * p[2];
    }
}
