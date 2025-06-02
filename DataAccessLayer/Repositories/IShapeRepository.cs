using DataAccessLayer.DTOs;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface IShapeRepository
    {
        void Add(ShapeCalculation shape);
        void Delete(int id);
        List<ShapeCalculationDto> GetAll();
        void Update(ShapeCalculation shape);
    }
}
