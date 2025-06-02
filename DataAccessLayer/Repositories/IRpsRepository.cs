using DataAccessLayer.DTOs;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface IRpsRepository
    {
        void AddRPSgame(RPSgame game);
        List<RPSgameDto> GetAllRPSgames();
        RPSgameDto GetLastGame();
    }
}
