namespace Service.Shapes.Strategy
{
    public class TriangleStrategy : IShapeStrategy
    {
        public string ShapeType => "Triangel";
        public string[] ParameterPrompts => new[] { "Sida A", "Sida B", "Sida C" };

        public double CalculateArea(double[] p)
        {
            if (!IsValidTriangle(p[0], p[1], p[2]))
                return -88;

            double s = (p[0] + p[1] + p[2]) / 2;
            return Math.Sqrt(s * (s - p[0]) * (s - p[1]) * (s - p[2]));
        }

        public double CalculatePerimeter(double[] p) => p[0] + p[1] + p[2];
        private bool IsValidTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }
    }
}
