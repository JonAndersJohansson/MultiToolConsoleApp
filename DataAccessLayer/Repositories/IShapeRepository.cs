using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface IShapeRepository
    {
        void Add(ShapeCalculation shape);
        IEnumerable<ShapeCalculation> GetAll();
    }
}
