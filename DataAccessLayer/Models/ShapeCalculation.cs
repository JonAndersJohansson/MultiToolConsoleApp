namespace DataAccessLayer.Models
{
    public class ShapeCalculation
    {
        public int Id { get; set; }
        public string ShapeType { get; set; }
        public double Param1 { get; set; }
        public double Param2 { get; set; }
        public double? Param3 { get; set; }
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public DateTime CalculatedAt { get; set; }
    }
}
