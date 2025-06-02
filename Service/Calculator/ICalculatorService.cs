using DataAccessLayer.DTOs;

namespace Service.Calculator
{
    public interface ICalculatorService
    {
        void DeleteCalculation(CalculatorOperationDto selected);
        List<CalculatorOperationDto> GetAllCalculations();
        void Save(CalculatorOperationDto calcDto, double[] parameters, double result, bool isNew);
    }
}