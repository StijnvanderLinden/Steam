using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Steam.Repositories;
using Steam.Context;

namespace Steam.Models
{
    public class Game
    {
        GameRepository repo = new GameRepository(new GameSQL());
        public int ID { get; set; }
        public string Naam { get; set; }
        public decimal Prijs { get; set; }
        public decimal Sterren { get; set; }
        public string Beschrijving { get; set; }
        public string IMGUrl { get; set; }
        public List<Bestelling> Bestellingen { get; set; }
        public List<Review> Reviews { get; set; }
        public int UitgeverID { get; set; }

        public Game()
        {

        }
        public Game(string naam, decimal prijs, int uitgeverID, decimal sterren, string beschrijving, string imgurl)
        {
            Naam = naam;
            Prijs = prijs;
            Sterren = sterren;
            Beschrijving = beschrijving;
            IMGUrl = imgurl;
            Bestellingen = new List<Bestelling>();
            Reviews = new List<Review>();
            UitgeverID = uitgeverID;
        }

        public Game(int id, string naam, decimal prijs, int uitgeverID, decimal sterren, string beschrijving, string imgurl)
        {
            ID = id;
            Naam = naam;
            Prijs = prijs;
            Sterren = sterren;
            Beschrijving = beschrijving;
            IMGUrl = imgurl;
            Bestellingen = new List<Bestelling>();
            Reviews = new List<Review>();
            UitgeverID = uitgeverID;
        }

        public void UpdateSterren(Review review)
        {
            Reviews.Add(review);
            decimal totaalSterren = 0;
            if(Reviews.Count > 0)
            {
                totaalSterren = 0;
                foreach (Review r in Reviews)
                {
                    totaalSterren += r.AantalSterren;
                }
            }
            else
            {
                totaalSterren = review.AantalSterren;
            }
            Sterren = totaalSterren / Reviews.Count;
            Math.Round(Sterren, 1);
            repo.UpdateSterren(this);
        }
    }
}