using DataAccessLayer.Models;

namespace Service.Shapes
{
    public interface IShapeService
    {
        List<ShapeCalculation> GetAllShapes();
        void Save(ShapeCalculation shape, double[] parameters, double area, double perimeter);
    }
}
