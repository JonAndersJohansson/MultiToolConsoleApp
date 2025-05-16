using DataAccessLayer.Models;
using RPS.UI;
using Service.RPS;
using Spectre.Console;

namespace RPS.ReadAll
{
    public class ReadAllGames : IReadAllGames
    {
        private readonly IRpsService _rpsService;

        public ReadAllGames(IRpsService rpsService)
        {
            _rpsService = rpsService;
        }
        public void ShowAllGames()
        {
            var matches = _rpsService.GetAllGames();
            int pageSize = 8;
            int page = 0;

            while (true)
            {
                Console.Clear();
                Graphics.RenderRPS();

                ShowChart(matches);

                ShowTable(matches, page, pageSize);

                AnsiConsole.MarkupLine("[grey]  Pil Upp/Ner för att byta sida. Tryck [red]ESC[/] för att gå tillbaka.[/]");
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.DownArrow && (page + 1) * pageSize < matches.Count)
                    page++;
                else if (key == ConsoleKey.UpArrow && page > 0)
                    page--;
                else if (key == ConsoleKey.Escape)
                    break;
            }
        }

        private void ShowTable(List<RPSgame> matches, int page, int pageSize)
        {
            // Ta fram sidans poster
            var currentPage = matches.Skip(page * pageSize).Take(pageSize).ToList();
            // Beräkna antal sidor
            var totalPages = (int)Math.Ceiling(matches.Count / (double)pageSize);
            // Visa som tabell
            var table = new Spectre.Console.Table()
                .Border(TableBorder.Rounded)
                .Title($"\n[aqua]Tidigare matcher (sida {page + 1} av {totalPages})[/]");

            table.AddColumn("Spelare");
            table.AddColumn("Dator");
            table.AddColumn("Resultat");
            table.AddColumn("Datum");

            foreach (var match in currentPage)
            {
                table.AddRow(
                    match.PlayerMove,
                    match.ComputerMove,
                    match.Result,
                    match.PlayedAt.ToShortDateString()
                );
            }

            AnsiConsole.Write(table);


        }

        private void ShowChart(List<RPSgame> matches)
        {
            int wins = matches.Count(x => x.Result == "Vinst");
            int losses = matches.Count(x => x.Result == "Förlust");
            int draws = matches.Count(x => x.Result == "Oavgjort");

            var chart = new BarChart()
                .Width(60)
                .Label("\n[aqua]Resultatstatistik[/]")
                .CenterLabel();

            chart.AddItem("Vinster", wins, Color.Green);
            chart.AddItem("Förluster", losses, Color.Red);
            chart.AddItem("Oavgjort", draws, Color.Yellow);

            AnsiConsole.Write(chart);
        }
    }
}
