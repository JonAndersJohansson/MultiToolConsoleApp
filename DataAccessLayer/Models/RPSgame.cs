using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class RPSgame
    {
        public int Id { get; set; }
        public string PlayerMove { get; set; }   // "Sten", "Sax", "Påse"
        public string ComputerMove { get; set; } // Samma
        public string Result { get; set; }       // "Vinst", "Förlust", "Oavgjort"
        public DateTime PlayedAt { get; set; }
    }

}
