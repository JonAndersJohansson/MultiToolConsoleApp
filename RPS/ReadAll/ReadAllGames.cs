using Microsoft.EntityFrameworkCore;
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
            int pageSize = 10;
            int page = 0;

            while (true)
            {
                Console.Clear();

                // Visa bar chart först
                ShowChart();

                // Ta fram sidans poster
                var currentPage = matches.Skip(page * pageSize).Take(pageSize).ToList();

                // Visa som tabell
                var table = new Table()
                    .Border(TableBorder.Rounded)
                    .Title($"[aqua]Tidigare matcher (sida {page + 1})[/]");

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

                AnsiConsole.MarkupLine("[grey]Pil Upp/Ner för att byta sida. Tryck [yellow]ESC[/] för att gå tillbaka.[/]");
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.DownArrow && (page + 1) * pageSize < matches.Count)
                    page++;
                else if (key == ConsoleKey.UpArrow && page > 0)
                    page--;
                else if (key == ConsoleKey.Escape)
                    break;
            }
        }
        private void ShowChart()
        {
            var chart = new BarChart()
                .Width(60)
                .Label("[green bold]Resultatstatistik[/]")
                .CenterLabel();

            chart.AddItem("Vinster", wins, Color.Green);
            chart.AddItem("Förluster", losses, Color.Red);
            chart.AddItem("Oavgjort", draws, Color.Yellow);

            AnsiConsole.Write(chart);
        }
    }
}
