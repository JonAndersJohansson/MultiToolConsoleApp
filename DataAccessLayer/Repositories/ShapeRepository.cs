using DataAccessLayer.Data;
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
            if (shape == null)
            {
                throw new ArgumentNullException(nameof(shape));
            }
            _dbContext.ShapeCalculations.Update(shape);
            _dbContext.SaveChanges();
        }
        public List<ShapeCalculation> GetAll()
        {
            return _dbContext.ShapeCalculations
                .OrderByDescending(s => s.CalculatedAt)
                .ToList();
        }
        public void Delete(int id)
        {
            var shape = _dbContext.ShapeCalculations.Find(id);
            if (shape == null)
            {
                throw new KeyNotFoundException($"Shape with ID {id} not found.");
            }
            _dbContext.ShapeCalculations.Remove(shape);
            _dbContext.SaveChanges();
        }
    }
}
