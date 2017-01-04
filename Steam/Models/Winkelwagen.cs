using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam.Models
{
    public class Winkelwagen
    {
        public int ID { get; set; }
        public Speler Speler { get; set; }
        public List<Game> Games { get; set; }
        public Winkelwagen()
        {
            Games = new List<Game>();
        }
        public Winkelwagen(int id)
        {
            ID = id;
            Games = new List<Game>();
        }
    }
}