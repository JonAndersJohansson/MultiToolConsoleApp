namespace DataAccessLayer.Models
{
    public class CalculatorOperation
    {
        public int Id { get; set; }
        public double? Number1 { get; set; }
        public double? Number2 { get; set; }
        public string Operator { get; set; }
        public double Result { get; set; }
        public DateTime PerformedAt { get; set; }
    }
}
