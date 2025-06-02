using DataAccessLayer.DTOs;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface ICalculatorRepository
    {
        void Add(CalculatorOperation calcEntity);
        void Update(CalculatorOperation calcEntity);
        void Delete(int id);
        List<CalculatorOperationDto> GetAll();
    }
}