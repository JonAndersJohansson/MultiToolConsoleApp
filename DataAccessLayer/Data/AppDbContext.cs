using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ShapeCalculation> ShapeCalculations { get; set; }
        public DbSet<CalculatorOperation> CalculatorOperations { get; set; }
        public DbSet<RPSgame> RpsGames { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
