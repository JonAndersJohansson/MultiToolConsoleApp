namespace Service.Calculator.Strategy
{
    public class AdditionStrategy : ICalculatorStrategy
    {
        public string Operator => "+";
        public string[] ParameterPrompts => new[] { "Tal 1", "Tal 2" };

        public double GetResult(double[] parameters)
        {
            if (parameters.Length != 2)
                throw new ArgumentException("Addition kräver två parametrar.");
            return parameters[0] + parameters[1];
        }
    }
}
