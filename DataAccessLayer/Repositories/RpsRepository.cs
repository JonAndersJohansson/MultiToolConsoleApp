using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RpsRepository : IRpsRepository
    {
        private readonly AppDbContext _dbContext;

        public RpsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddRPSgame(RPSgame game)
        {
            _dbContext.RpsGames.Add(game);
            _dbContext.SaveChanges();
        }
        public List<RPSgame> GetAllRPSgames()
        {
            return _dbContext.RpsGames
                .OrderByDescending(x => x.PlayedAt)
                .ToList();
                
        }

        public RPSgame? GetLastGame()
        {
            return _dbContext.RpsGames
                .OrderByDescending(x => x.PlayedAt)
                .FirstOrDefault();
        }
    }
}
