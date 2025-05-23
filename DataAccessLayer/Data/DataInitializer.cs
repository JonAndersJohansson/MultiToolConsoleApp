using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public static class DataInitializer
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.Migrate();

            if (!context.ShapeCalculations.Any())
            {
                context.ShapeCalculations.AddRange(new[]
                {
                    new ShapeCalculation
                    {
                        ShapeType = "Rektangel",
                        Param1 = 5,
                        Param2 = 3,
                        Area = 15,
                        Perimeter = 16,
                        CalculatedAt = DateTime.Now.AddDays(-2)
                    },
                    new ShapeCalculation
                    {
                        ShapeType = "Triangel",
                        Param1 = 4,
                        Param2 = 6,
                        Param3 = 5,
                        Area = 12,
                        Perimeter = 15,
                        CalculatedAt = DateTime.Now.AddDays(-1)
                    },
                    new ShapeCalculation
                    {
                        ShapeType = "Romb",
                        Param1 = 6,
                        Param2 = 8,
                        Area = 24,
                        Perimeter = 28,
                        CalculatedAt = DateTime.Now.AddDays(-1)
                    },
                    new ShapeCalculation
                    {
                        ShapeType = "Parallellogram",
                        Param1 = 5,
                        Param2 = 4,
                        Param3 = 5,
                        Area = 20, 
                        Perimeter = 20,
                        CalculatedAt = DateTime.Now.AddDays(-1)
                    }
                });
            }

            if (!context.CalculatorOperations.Any())
            {
                context.CalculatorOperations.AddRange(new[]
                {
                    new CalculatorOperation
                    {
                        Number1 = 10,
                        Number2 = 2,
                        Operator = "+",
                        Result = 12,
                        PerformedAt = DateTime.Now.AddDays(-3)
                    },
                    new CalculatorOperation
                    {
                        Number1 = 9,
                        Operator = "√",
                        Result = 3,
                        PerformedAt = DateTime.Now.AddDays(-2)
                    }
                });
            }


            context.SaveChanges();
        }
    }
}
