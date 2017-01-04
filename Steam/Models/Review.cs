using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam.Models
{
    public class Review
    {
        public int ID { get; set; }
        public string Titel { get; set; }
        public string Comment { get; set; }
        public int AantalSterren { get; set; }
        public Game Game { get; set; }
        public Speler Speler { get; set; }
        public int GameID { get; set; }
        public int SpelerID { get; set; }

        public Review(int gameID, int spelerID, string titel, string comment, int aantalsterren)
        {
            GameID = gameID;
            SpelerID = spelerID;
            Titel = titel;
            Comment = comment;
            AantalSterren = aantalsterren;
        }

        public Review(int id, int gameID, int spelerID, string titel, string comment, int aantalsterren)
        {
            ID = id;
            GameID = gameID;
            SpelerID = spelerID;
            Titel = titel;
            Comment = comment;
            AantalSterren = aantalsterren;
        }
    }
}