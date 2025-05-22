using DataAccessLayer.Models;

namespace Service.Shapes
{
    public interface IShapeService
    {
        void Save(ShapeCalculation shape, double[] parameters, double area, double perimeter);
    }
}
