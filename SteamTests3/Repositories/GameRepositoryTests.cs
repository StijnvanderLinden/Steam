using Microsoft.VisualStudio.TestTools.UnitTesting;
using Steam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steam.Models;
using Steam.Context;

namespace Steam.Repositories.Tests
{
    [TestClass()]
    public class GameRepositoryTests
    {
        [TestMethod()]
        public void GetReviewsByGameTest()
        {
            Game game = new Game(4, "Dishonored", 20, 8, 0, "Het spel is een stealth-action-adventure game van de eerste persoon. Waar kunt u een moordenaar, maar niet noodzakelijk zijn om iemand te vermoorden. Waar u kunt verkennen van het doel van het vernietigen van al zijn garnizoen met de hulp van explosieven en vallen. Waar het mogelijk is om de meest brute geweld en om naar het beschermde gebied, zodat niemand weet het.", "http://i.imgur.com/pZDqQOA.jpg");
            List<Review> reviews = new List<Review>();
            reviews.Add(new Review(4, 15, "Niet normaal", null, 5));
            reviews.Add(new Review(4, 2, "test", null, 3));
            reviews.Add(new Review(4, 2, "test", null, 3));
            GameRepository repo = new GameRepository(new GameSQL());
            List<Review> datareviews = repo.GetReviewsByGame(game);
            Assert.AreEqual(datareviews[0].AantalSterren, reviews[0].AantalSterren);
            Assert.AreEqual(datareviews[1].Titel, reviews[1].Titel);
            Assert.AreEqual(datareviews[2].SpelerID, reviews[2].SpelerID);
        }
    }
}