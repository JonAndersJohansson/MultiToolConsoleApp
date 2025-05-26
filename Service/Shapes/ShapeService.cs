using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace Service.Shapes
{
    public class ShapeService : IShapeService
    {
        private readonly IShapeRepository _shapeRepo;

        public ShapeService(IShapeRepository shapeRepo)
        {
            _shapeRepo = shapeRepo;
        }
        public void Save(ShapeCalculation shape, double[] parameters, double area, double perimeter)
        {
            shape.Param1 = parameters.ElementAtOrDefault(0);
            shape.Param2 = parameters.ElementAtOrDefault(1);
            shape.Param3 = parameters.ElementAtOrDefault(2);
            shape.Area = area;
            shape.Perimeter = perimeter;
            shape.CalculatedAt = DateTime.Now;

            _shapeRepo.Add(shape);
        }
        public List<ShapeCalculation> GetAllShapes()
        {
            return _shapeRepo.GetAll().ToList();
        }
    }
}
