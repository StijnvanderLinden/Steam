using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steam.Models;

namespace Steam.Context
{
    public interface ISpeler
    {
        void AddReview(Review review);
        void AddBestelling(Bestelling bestelling);
        List<Game> GetBibliotheek(Speler speler);
    }
}
