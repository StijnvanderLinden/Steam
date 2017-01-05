using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Steam.Models;

namespace Steam.Context
{
    public class SpelerSQL : ISpeler
    {
        public void AddReview(Review review)
        {
            string query = "INSERT INTO REVIEW (GameID, AccountID, Titel, Comment, AantalSterren) VALUES (@GameID, @AccountID, @Titel, @Comment, @Sterren)";
            var command = new SqlCommand(query);
            command.Parameters.AddWithValue("@GameID", review.GameID);
            command.Parameters.AddWithValue("@AccountID", review.SpelerID);
            command.Parameters.AddWithValue("@Titel", review.Titel);
            command.Parameters.AddWithValue("@Comment", review.Comment);
            command.Parameters.AddWithValue("@Sterren", review.AantalSterren);
            DatabaseConnection.DbConnectionInstance.ExecuteQuery(command);
        }

        public List<Game> GetBibliotheek(Speler speler)
        {
            string query = "SELECT * FROM BIBLIOTHEEK WHERE AccountID = @ID";
            var command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", speler.ID);
            SqlDataReader reader = DatabaseConnection.DbConnectionInstance.ExecuteQueryReader(command);
            List<Game> games = new List<Game>();
            while (reader.Read())
            {
                Game game = new Game();
                game.ID = reader.GetInt32(1);
                games.Add(game);
            }
            if (games.Count() > 0)
            {
                return games;
            }
            else
            {
                return null;
            }

        }
    }
}