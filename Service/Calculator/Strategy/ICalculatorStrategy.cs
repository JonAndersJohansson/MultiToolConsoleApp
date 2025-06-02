namespace Service.Calculator.Strategy
{
    public interface ICalculatorStrategy
    {
        /// <summary>
        /// Operatorn som strategin stödjer, t.ex. "+", "-", "*", "/", "√", "%".
        /// </summary>
        string Operator { get; }

        /// <summary>
        /// Beskrivningar av parametrar som ska efterfrågas från användaren.
        /// Exempel: "Tal 1", "Tal 2".
        /// </summary>
        string[] ParameterPrompts { get; }

        /// <summary>
        /// Beräknar resultatet baserat på de inmatade parametrarna.
        /// </summary>
        /// <param name="parameters">Parametrar som användaren har matat in.</param>
        /// <returns>Resultatet av beräkningen.</returns>
        double GetResult(double[] parameters);
    }
}
