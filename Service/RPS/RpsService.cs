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
            //Returnera 9 olika varianter istället!?

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

            var result = GenerateReturnResult(userInput, botMove);

            //if (userInput == botMove)
            //{
            //    return GameResult.Draw;
            //}
            //else if ((userInput == "Sten" && botMove == "Sax") ||
            //         (userInput == "Sax" && botMove == "Påse") ||
            //         (userInput == "Påse" && botMove == "Sten"))
            //{
            //    return GameResult.Win;
            //}
            //else
            //{
            //    return GameResult.Lose;
            //}
        }

        private GameResult GenerateReturnResult(string userInput, string botMove)
        {
            throw new NotImplementedException();
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
