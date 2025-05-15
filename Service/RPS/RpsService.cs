using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
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
            _rpsRepo.AddRPSgame(rpsGame);

            return GenerateReturnResult(userInput, botMove);
        }

        private GameResult GenerateReturnResult(string userInput, string botMove)
        {
            return (userInput, botMove) switch
            {
                ("Scissors", "Scissors") => GameResult.ScissorsScissors,
                ("Scissors", "Rock") => GameResult.ScissorsRock,
                ("Scissors", "Paper") => GameResult.ScissorsPaper,
                ("Rock", "Rock") => GameResult.RockRock,
                ("Rock", "Scissors") => GameResult.RockScissors,
                ("Rock", "Paper") => GameResult.RockPaper,
                ("Paper", "Paper") => GameResult.PaperPaper,
                ("Paper", "Rock") => GameResult.PaperRock,
                ("Paper", "Scissors") => GameResult.PaperScissors,
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
    }
}
