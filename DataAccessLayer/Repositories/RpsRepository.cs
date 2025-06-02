using DataAccessLayer.Data;
using DataAccessLayer.DTOs;
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
        public List<RPSgameDto> GetAllRPSgames()
        {
            return _dbContext.RpsGames
                .OrderByDescending(x => x.PlayedAt)
                .Select(x => new RPSgameDto
                {
                    Id = x.Id,
                    PlayerMove = x.PlayerMove,
                    ComputerMove = x.ComputerMove,
                    Result = x.Result,
                    PlayedAt = x.PlayedAt,
                    WinRate = x.WinRate
                })
                .ToList();
        }

        public RPSgameDto? GetLastGame()
        {
            return _dbContext.RpsGames
                .OrderByDescending(x => x.PlayedAt)
                .Select(x => new RPSgameDto
                {
                    Id = x.Id,
                    PlayerMove = x.PlayerMove,
                    ComputerMove = x.ComputerMove,
                    Result = x.Result,
                    PlayedAt = x.PlayedAt,
                    WinRate = x.WinRate
                })
                .FirstOrDefault();
        }
    }
}
