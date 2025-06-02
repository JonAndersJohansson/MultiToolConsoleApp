using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IRpsRepository
    {
        void AddRPSgame(RPSgame game);
        List<RPSgameDto> GetAllRPSgames();
        RPSgameDto GetLastGame();
    }
}
