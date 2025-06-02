namespace Service.Calculator.Strategy
{
    public interface ICalculatorStrategy
    {
        string Operator { get; }

        string[] ParameterPrompts { get; }

        double GetResult(double[] parameters);
    }
}
