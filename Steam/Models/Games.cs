using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Steam.Repositories;
using Steam.Context;

namespace Steam.Models
{
    public class Games
    {
        GameRepository repo = new GameRepository(new GameSQL());
        public List<Game> games { get; set; }
        public Games()
        {
            games = GetAllGames();
        }

        public Game GetGameByID(int ID)
        {
            return repo.GetGameByID(ID);
        }

        public List<Game> GetAllGames()
        {
            return repo.GetAllGames();
        }

        public List<Game> CheckCategorie(int categorieID)
        {
            return repo.CheckCategorie(categorieID);
        }
    }
}