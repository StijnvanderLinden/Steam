using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Steam.Repositories;
using Steam.Context;

namespace Steam.Models
{
    public class Speler : Account
    {
        SpelerRepository sr = new SpelerRepository(new SpelerSQL());
        public List<Game> Games { get; set; }
        public Winkelwagen Winkelwagen { get; set; }

        public Speler()
        {
            Games = new List<Game>();
            Winkelwagen = new Winkelwagen();
        }
        public Speler(string inlognaam, string wachtwoord) : base(inlognaam, wachtwoord)
        {
            Inlognaam = inlognaam;
            Wachtwoord = wachtwoord;
            Games = new List<Game>();
            Winkelwagen = new Winkelwagen();
        }
        public Speler(string nickname, string inlognaam, string wachtwoord, string woonplaats, string emailadres, List<Game> games, Winkelwagen winkelwagen) : base(nickname, inlognaam, wachtwoord, woonplaats, emailadres)
        {
            Nickname = nickname;
            Inlognaam = inlognaam;
            Wachtwoord = wachtwoord;
            Woonplaats = woonplaats;
            Emailadres = emailadres;
            Games = games;
            Winkelwagen = winkelwagen;
        }
        public Speler(int id, string nickname, string inlognaam, string wachtwoord, string woonplaats, string emailadres, List<Game> games, Winkelwagen winkelwagen) : base(id, nickname, inlognaam, wachtwoord, woonplaats, emailadres)
        {
            ID = id;
            Nickname = nickname;
            Inlognaam = inlognaam;
            Wachtwoord = wachtwoord;
            Woonplaats = woonplaats;
            Emailadres = emailadres;
            Games = games;
            Winkelwagen = winkelwagen;
        }
    }
}