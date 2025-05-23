using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Service.RPS.Enum;

namespace Service.RPS
{
    public class RpsService : IRpsService
    {
        private readonly IRpsRepository _rpsRepo;

        public RpsService(IRpsRepository rpsRepo)
        {
            _rpsRepo = rpsRepo;
        }
        public GameResult CalculateResult(string userInput)
        {
            string botMove = GenerateBotMove();

            var rpsGame  = new RPSgame();
            rpsGame.PlayerMove = userInput;
            rpsGame.ComputerMove = botMove;
            rpsGame.PlayedAt = DateTime.Now;
            rpsGame.Result = botMove switch
            {
                "Sten" when userInput == "Sax" => "Förlust",
                "Sax" when userInput == "Påse" => "Förlust",
                "Påse" when userInput == "Sten" => "Förlust",
                _ when userInput == botMove => "Oavgjort",
                _ => "Vinst"
            };

            rpsGame = CalculateWinRatio(rpsGame);

            _rpsRepo.AddRPSgame(rpsGame);

            return GenerateReturnResult(userInput, botMove);
        }


        public List<RPSgame> GetAllGames()
        {
            return _rpsRepo.GetAllRPSgames();
        }
        public decimal GetCurrentWinRatio()
        {
            var lastGame = _rpsRepo.GetLastGame();
            var currentWinRatio = lastGame.WinRate;
            return currentWinRatio;
        }

        private GameResult GenerateReturnResult(string userInput, string botMove)
        {
            return (userInput, botMove) switch
            {
                ("Sax", "Sax") => GameResult.ScissorsScissors,
                ("Sax", "Sten") => GameResult.ScissorsRock,
                ("Sax", "Påse") => GameResult.ScissorsPaper,
                ("Sten", "Sten") => GameResult.RockRock,
                ("Sten", "Sax") => GameResult.RockScissors,
                ("Sten", "Påse") => GameResult.RockPaper,
                ("Påse", "Påse") => GameResult.PaperPaper,
                ("Påse", "Sten") => GameResult.PaperRock,
                ("Påse", "Sax") => GameResult.PaperScissors,
                _ => GameResult.Error
            };
        }

        private string GenerateBotMove()
        {
            var random = new Random();
            var computerChoice = random.Next(1, 4);
            return computerChoice switch
            {
                1 => "Sten",
                2 => "Sax",
                3 => "Påse",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private RPSgame CalculateWinRatio(RPSgame rpsGame)
        {
            int totalGames = _rpsRepo.GetAllRPSgames().Count() + 1;

            int totalWins = _rpsRepo.GetAllRPSgames().Count(x => x.Result == "Vinst") + (rpsGame.Result == "Vinst" ? 1 : 0);

            decimal winRate = totalGames > 0 ? (decimal)totalWins / totalGames * 100 : 0;

            rpsGame.WinRate = Math.Round(winRate, 2);
            return rpsGame;
        }
    }
}
