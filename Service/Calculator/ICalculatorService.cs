using DataAccessLayer.DTOs;

namespace Service.Calculator
{
    public interface ICalculatorService
    {
        void Save(CalculatorOperationDto calcDto, double[] parameters, double result, bool isNew);
    }
}