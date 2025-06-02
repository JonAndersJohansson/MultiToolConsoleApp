using DataAccessLayer.Data;
using DataAccessLayer.DTOs;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public class ShapeRepository : IShapeRepository
    {
        private readonly AppDbContext _dbContext;

        public ShapeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(ShapeCalculation shape)
        {
            if (shape == null)
            {
                throw new ArgumentNullException(nameof(shape));
            }
            _dbContext.ShapeCalculations.Add(shape);
            _dbContext.SaveChanges();
        }
        public void Update(ShapeCalculation shape)
        {
            var existingShape = _dbContext.ShapeCalculations.Find(shape.Id);
            if (existingShape == null)
            {
                throw new KeyNotFoundException($"Form med ID: {shape.Id} hittades inte.");
            }

            // Uppdatera värden
            existingShape.ShapeType = shape.ShapeType;
            existingShape.Param1 = shape.Param1;
            existingShape.Param2 = shape.Param2;
            existingShape.Param3 = shape.Param3;
            existingShape.Area = shape.Area;
            existingShape.Perimeter = shape.Perimeter;
            existingShape.CalculatedAt = shape.CalculatedAt;

            _dbContext.SaveChanges();
        }
        public List<ShapeCalculationDto> GetAll()
        {
            return _dbContext.ShapeCalculations
                .OrderByDescending(s => s.CalculatedAt)
                .Select(s => new ShapeCalculationDto
                {
                    Id = s.Id,
                    ShapeType = s.ShapeType,
                    Param1 = s.Param1,
                    Param2 = s.Param2,
                    Param3 = s.Param3,
                    Area = s.Area,
                    Perimeter = s.Perimeter,
                    CalculatedAt = s.CalculatedAt
                })
                .ToList();
        }

        public void Delete(int id)
        {
            var shape = _dbContext.ShapeCalculations.Find(id);
            if (shape == null)
            {
                throw new KeyNotFoundException($"Form med ID: {id} hittades inte.");
            }
            _dbContext.ShapeCalculations.Remove(shape);
            _dbContext.SaveChanges();
        }
    }
}
