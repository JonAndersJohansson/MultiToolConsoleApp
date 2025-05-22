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
    }
}
