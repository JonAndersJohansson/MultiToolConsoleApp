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
        //List<RPSgame> GetAllGames();
        //RPSgame GetGameById(int id);
        //void DeleteGame(int id);
        //void UpdateGame(RPSgame game);
    }
}
