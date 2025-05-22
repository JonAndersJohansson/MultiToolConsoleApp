namespace Service.Shapes.Strategy
{
    public class ParallelogramStrategy : IShapeStrategy
    {
        public string ShapeType => "Parallellogram";
        public string[] ParameterPrompts => new[] { "Bas", "Höjd", "Sida" };

        public double CalculateArea(double[] p) => p[0] * p[1];
        public double CalculatePerimeter(double[] p) => 2 * (p[0] + p[2]);
    }
}
