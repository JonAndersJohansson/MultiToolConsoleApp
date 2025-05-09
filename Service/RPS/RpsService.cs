using DataAccessLayer.Models;
using Service.RPS.Enum;

namespace Service.RPS
{
    public class RpsService : IRpsService
    {
        public GameResult CalculateResult(string userInput)
        {
            //Returnera 9 olika varianter istället!?


            var random = new Random();
            var computerChoice = random.Next(1, 4);
            string computerChoiceString = computerChoice switch
            {
                1 => "Sten",
                2 => "Sax",
                3 => "Påse",
                _ => throw new ArgumentOutOfRangeException()
            };


            var rspGame  = new RPSgame();
            rspGame.PlayerMove = userInput;
            rspGame.ComputerMove = computerChoiceString;

            if (userInput == computerChoiceString)
            {
                return GameResult.Draw;
            }
            else if ((userInput == "Sten" && computerChoiceString == "Sax") ||
                     (userInput == "Sax" && computerChoiceString == "Påse") ||
                     (userInput == "Påse" && computerChoiceString == "Sten"))
            {
                return GameResult.Win;
            }
            else
            {
                return GameResult.Lose;
            }
        }
    }
}
