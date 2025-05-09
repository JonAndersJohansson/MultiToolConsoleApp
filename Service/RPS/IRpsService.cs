using Service.RPS.Enum;

namespace Service.RPS
{
    public interface IRpsService
    {
        GameResult CalculateResult(string userInput);
    }
}
