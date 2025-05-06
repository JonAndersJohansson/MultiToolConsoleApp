using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public static class DataInitializer
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.Migrate(); // Kör migrationer om inte redan gjort

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

            if (!context.RpsGames.Any())
            {
                context.RpsGames.AddRange(new[]
                {
                    new RPSgame
                    {
                        PlayerMove = "Sten",
                        ComputerMove = "Sax",
                        Result = "Vinst",
                        PlayedAt = DateTime.Now.AddDays(-5)
                    },
                    new RPSgame
                    {
                        PlayerMove = "Sax",
                        ComputerMove = "Sten",
                        Result = "Förlust",
                        PlayedAt = DateTime.Now.AddDays(-4)
                    }
                });
            }

            context.SaveChanges();
        }
    }
}
