using DataAccessLayer.Models;

namespace Shapes.Edit
{
    public interface IEditShape
    {
        void AskForShapeParameters(ShapeCalculation shape, bool isCreateNewShape);
        void EditSelectedShape(ShapeCalculation selected);
    }
}
