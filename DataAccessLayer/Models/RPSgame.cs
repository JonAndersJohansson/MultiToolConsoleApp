namespace DataAccessLayer.Models
{
    public class RPSgame
    {
        public int Id { get; set; }
        public string PlayerMove { get; set; }   // "Sten", "Sax", "Påse"
        public string ComputerMove { get; set; } // Samma
        public string Result { get; set; }       // "Vinst", "Förlust", "Oavgjort"
        public DateTime PlayedAt { get; set; }
        public decimal WinRate { get; set; } // Procentuell vinststatistik
    }
}
