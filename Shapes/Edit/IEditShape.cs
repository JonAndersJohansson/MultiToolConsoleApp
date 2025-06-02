using DataAccessLayer.DTOs;

namespace Shapes.Edit
{
    public interface IEditShape
    {
        void AskForShapeParameters(ShapeCalculationDto shapeDto, bool isCreateNewShape);
        void EditSelectedShape(ShapeCalculationDto selected);
    }
}
