using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ShapeCalculation
    {
        public int Id { get; set; }
        public string ShapeType { get; set; } // form
        public double Param1 { get; set; }    // bredd
        public double Param2 { get; set; }    // höjd
        public double? Param3 { get; set; }   // nullable Ex. för triangel osv
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public DateTime CalculatedAt { get; set; }
    }

}
