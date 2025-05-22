namespace Service.Shapes.Strategy
{
    public class RhombusStrategy : IShapeStrategy
    {
        public string ShapeType => "Romb";
        public string[] ParameterPrompts => new[] { "Diagonal 1", "Diagonal 2" };

        public double CalculateArea(double[] p)
        {
            return (p[0] * p[1]) / 2;
        }

        public double CalculatePerimeter(double[] p)
        {
            double halfD1 = p[0] / 2;
            double halfD2 = p[1] / 2;

            double side = Math.Sqrt(halfD1 * halfD1 + halfD2 * halfD2);
            return 4 * side;
        }
    }

}
