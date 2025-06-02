namespace Service.Calculator.Strategy
{
    public class MultiplicationStrategy : ICalculatorStrategy
    {
        public string Operator => "*";
        public string[] ParameterPrompts => new[] { "Tal 1", "Tal 2" };

        public double GetResult(double[] parameters)
        {
            if (parameters.Length != 2)
                throw new ArgumentException("Multiplikation kräver två parametrar.");
            return parameters[0] * parameters[1];
        }
    }
}
