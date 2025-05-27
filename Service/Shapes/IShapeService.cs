using DataAccessLayer.Models;

namespace Service.Shapes
{
    public interface IShapeService
    {
        void DeleteShape(ShapeCalculation selected);
        List<ShapeCalculation> GetAllShapes();
        void Save(ShapeCalculation shape, double[] parameters, double area, double perimeter, bool isCreateNewShape);
    }
}
