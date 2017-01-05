using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Steam.Models;

namespace Steam.Context
{
    public class BeheerderSQL : IBeheerder
    {
        DatabaseConnection databaseConnection;
        public BeheerderSQL()
        {
            databaseConnection = new DatabaseConnection();
        }

        public Beheerder GetBeheerder(Beheerder beheerder)
        {
            string query = "SELECT * FROM ACCOUNT WHERE INLOGNAAM = @inlognaam AND WACHTWOORD = @wachtwoord";
            var command = new SqlCommand(query);
            command.Parameters.AddWithValue("@inlognaam", beheerder.Inlognaam);
            command.Parameters.AddWithValue("@wachtwoord", beheerder.Wachtwoord);
            SqlDataReader reader = databaseConnection.ExecuteQueryReader(command);
            if (reader.Read())
            {
                beheerder.ID = reader.GetInt32(0);
                beheerder.Nickname = reader.GetString(1);
                beheerder.Inlognaam = reader.GetString(2);
                beheerder.Wachtwoord = reader.GetString(3);
                beheerder.Woonplaats = reader.GetString(4);
                beheerder.Emailadres = reader.GetString(5);
                return beheerder;
            }
            return null;
        }

        public void DeleteSpeler(Speler speler)
        {
            throw new NotImplementedException();
        }
        public bool CheckGegevens(string inlognaam, string wachtwoord)
        {
            string query = "SELECT INLOGNAAM, WACHTWOORD FROM ACCOUNT WHERE INLOGNAAM = @inlognaam AND WACHTWOORD = @wachtwoord";
            var command = new SqlCommand(query);
            command.Parameters.AddWithValue("@inlognaam", inlognaam);
            command.Parameters.AddWithValue("@wachtwoord", wachtwoord);
            SqlDataReader reader = databaseConnection.ExecuteQueryReader(command);

            while (reader.Read())
            {
                if (reader.GetString(0) == inlognaam && reader.GetString(1) == wachtwoord)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckIfSpeler(string inlognaam, string wachtwoord)
        {
            string query = "SELECT INLOGNAAM FROM ACCOUNT WHERE INLOGNAAM = @inlognaam AND WACHTWOORD = @wachtwoord AND ID IN (SELECT ID FROM SPELER)";
            var command = new SqlCommand(query);
            command.Parameters.AddWithValue("@inlognaam", inlognaam);
            command.Parameters.AddWithValue("@wachtwoord", wachtwoord);
            SqlDataReader reader = databaseConnection.ExecuteQueryReader(command);
            while (reader.Read())
            {
                return true;
            }
            return false;
        }

        public bool CheckInlognaam(string inlognaam)
        {
            string query = "SELECT INLOGNAAM FROM ACCOUNT WHERE INLOGNAAM = @inlognaam";
            var command = new SqlCommand(query);
            command.Parameters.AddWithValue("@inlognaam", inlognaam);
            SqlDataReader reader = databaseConnection.ExecuteQueryReader(command);
            while (reader.Read())
            {
                return true;
            }
            return false;
        }

        public bool CheckNickname(string nickname)
        {
            string query = "SELECT INLOGNAAM FROM ACCOUNT WHERE NICKNAME = @nickname";
            var command = new SqlCommand(query);
            command.Parameters.AddWithValue("@nickname", nickname);
            SqlDataReader reader = databaseConnection.ExecuteQueryReader(command);
            while (reader.Read())
            {
                return true;
            }
            return false;
        }

        public Speler GetSpeler(Speler speler)
        {
            string query = "SELECT * FROM ACCOUNT WHERE INLOGNAAM = @inlognaam AND WACHTWOORD = @wachtwoord";
            var command = new SqlCommand(query);
            command.Parameters.AddWithValue("@inlognaam", speler.Inlognaam);
            command.Parameters.AddWithValue("@wachtwoord", speler.Wachtwoord);
            SqlDataReader reader = databaseConnection.ExecuteQueryReader(command);
            if (reader.Read())
            {
                speler.ID = reader.GetInt32(0);
                speler.Nickname = reader.GetString(1);
                speler.Inlognaam = reader.GetString(2);
                speler.Wachtwoord = reader.GetString(3);
                speler.Woonplaats = reader.GetString(4);
                speler.Emailadres = reader.GetString(5);
                return speler;
            }
            return null;
        }

        public void AddSpeler(Speler speler)
        {
            var command = new SqlCommand("AddSpeler");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@paraNickname", speler.Nickname));
            command.Parameters.Add(new SqlParameter("@paraInlognaam", speler.Inlognaam));
            command.Parameters.Add(new SqlParameter("@paraWachtwoord", speler.Wachtwoord));
            command.Parameters.Add(new SqlParameter("@paraWoonplaats", speler.Woonplaats));
            command.Parameters.Add(new SqlParameter("@paraEmailadres", speler.Emailadres));
            databaseConnection.ExecuteProcedure(command);
        }

        public Speler GetSpelerByID(int ID)
        {
            string query = "SELECT * FROM ACCOUNT WHERE ID = @ID";
            var command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ID", ID);
            SqlDataReader reader = databaseConnection.ExecuteQueryReader(command);
            while (reader.Read())
            {
                Speler speler = new Speler(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), new List<Game>(), new Winkelwagen());
                return speler;
            }
            return null;
        }
    }
}