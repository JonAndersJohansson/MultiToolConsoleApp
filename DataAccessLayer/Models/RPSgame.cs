namespace DataAccessLayer.Models
{
    public class RPSgame
    {
        public int Id { get; set; }
        public string PlayerMove { get; set; }
        public string ComputerMove { get; set; }
        public string Result { get; set; }
        public DateTime PlayedAt { get; set; }
        public decimal WinRate { get; set; }
    }
}
