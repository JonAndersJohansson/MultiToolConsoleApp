using DataAccessLayer.DTOs;

namespace Service.Shapes
{
    public interface IShapeService
    {
        void DeleteShape(ShapeCalculationDto selected);
        List<ShapeCalculationDto> GetAllShapes();
        void Save(ShapeCalculationDto shape, double[] parameters, double area, double perimeter, bool isCreateNewShape);
    }
}
