using DataAccessLayer.DTOs;

namespace Calculator.Edit
{
    public interface IEditCalculation
    {
        void AskForCalcParameters(CalculatorOperationDto calcDto, bool IsNew);
        void EditSelectedCalc(CalculatorOperationDto selected);
    }
}