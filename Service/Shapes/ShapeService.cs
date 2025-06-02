using DataAccessLayer.DTOs;
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
        public void Save(ShapeCalculationDto shapeDto, double[] parameters, double area, double perimeter, bool isCreateNewShape)
        {
            shapeDto.Param1 = parameters.ElementAtOrDefault(0);
            shapeDto.Param2 = parameters.ElementAtOrDefault(1);
            shapeDto.Param3 = parameters.ElementAtOrDefault(2);
            shapeDto.Area = area;
            shapeDto.Perimeter = perimeter;
            shapeDto.CalculatedAt = DateTime.Now;

            // Mappa DTO till Entitet
            var shapeEntity = new ShapeCalculation
            {
                Id = shapeDto.Id, // Viktigt vid update
                ShapeType = shapeDto.ShapeType,
                Param1 = shapeDto.Param1,
                Param2 = shapeDto.Param2,
                Param3 = shapeDto.Param3,
                Area = shapeDto.Area,
                Perimeter = shapeDto.Perimeter,
                CalculatedAt = shapeDto.CalculatedAt
            };

            if (isCreateNewShape)
                _shapeRepo.Add(shapeEntity);
            else
                _shapeRepo.Update(shapeEntity);
        }

        public List<ShapeCalculationDto> GetAllShapes()
        {
            return _shapeRepo.GetAll().ToList();
        }
        public void DeleteShape(ShapeCalculationDto selected)
        {
            if (selected == null)
                throw new ArgumentNullException(nameof(selected), "Selected shapeDto cannot be null.");
            
            _shapeRepo.Delete(selected.Id);
        }
    }
}
