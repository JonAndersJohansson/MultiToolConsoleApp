using DataAccessLayer.Data;
using DataAccessLayer.DTOs;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public class CalculatorRepository : ICalculatorRepository
    {
        private readonly AppDbContext _dbContext;

        public CalculatorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(CalculatorOperation calcEntity)
        {
            if (calcEntity == null)
            {
                throw new ArgumentNullException(nameof(calcEntity));
            }
            _dbContext.CalculatorOperations.Add(calcEntity);
            _dbContext.SaveChanges();
        }

        public void Update(CalculatorOperation calcEntity)
        {
            var existingCalc = _dbContext.CalculatorOperations.Find(calcEntity.Id);
            if (existingCalc == null)
            {
                throw new KeyNotFoundException($"Uträkning med ID: {calcEntity.Id} hittades inte.");
            }

            existingCalc.Number1 = calcEntity.Number1;
            existingCalc.Number2 = calcEntity.Number2;
            existingCalc.Operator = calcEntity.Operator;
            existingCalc.Result = calcEntity.Result;
            existingCalc.PerformedAt = calcEntity.PerformedAt;

            _dbContext.SaveChanges();
        }
        public List<CalculatorOperationDto> GetAll()
        {
            return _dbContext.CalculatorOperations
                .OrderByDescending(s => s.PerformedAt)
                .Select(c => new CalculatorOperationDto
                {
                    Id = c.Id,
                    Number1 = c.Number1,
                    Number2 = c.Number2,
                    Operator = c.Operator,
                    Result = c.Result,
                    PerformedAt = c.PerformedAt
                })
                .ToList();
        }

        public void Delete(int id)
        {
            var calc = _dbContext.CalculatorOperations.Find(id);
            if (calc == null)
            {
                throw new KeyNotFoundException($"Uträkning med ID {id} hittades inte.");
            }
            _dbContext.CalculatorOperations.Remove(calc);
            _dbContext.SaveChanges();
        }
    }
}
