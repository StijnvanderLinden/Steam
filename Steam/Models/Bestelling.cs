using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam.Models
{
    public class Bestelling
    {
        public int ID { get; set; }
        public int SpelerID { get; set; }
        public List<Game> Games { get; set; }
        public DateTime Besteldatum { get; set; }
        public decimal Prijs { get; set; }
        public Bestelling(int spelerid, List<Game> games, DateTime besteldatum)
        {
            SpelerID = spelerid;
            Games = games;
            Besteldatum = besteldatum;
        }
    }
}