using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace Service.Calculator
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ICalculatorRepository _calcRepo;

        public CalculatorService(ICalculatorRepository calculatorRepository)
        {
            _calcRepo = calculatorRepository;
        }
        public void Save(CalculatorOperationDto calcDto, double[] parameters, double result, bool isNew)
        {
            calcDto.Number1 = parameters.ElementAtOrDefault(0);
            calcDto.Number2 = parameters.ElementAtOrDefault(1);
            calcDto.Result = result;
            calcDto.PerformedAt = DateTime.Now;

            // Mappa DTO till Entitet
            var calcEntity = new CalculatorOperation
            {
                Id = calcDto.Id, // Viktigt vid update
                Number1 = calcDto.Number1,
                Number2 = calcDto.Number2,
                Operator = calcDto.Operator,
                Result = calcDto.Result,
                PerformedAt = calcDto.PerformedAt
            };


            if (isNew)
                _calcRepo.Add(calcEntity);
            else
                _calcRepo.Update(calcEntity);
        }
    }
}
