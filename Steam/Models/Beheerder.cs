using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam.Models
{
    public class Beheerder : Account
    {
        public Beheerder()
        {

        }
        public Beheerder(string inlognaam, string wachtwoord) : base(inlognaam, wachtwoord)
        {
            Inlognaam = inlognaam;
            Wachtwoord = wachtwoord;
        }
        public Beheerder(string nickname, string inlognaam, string wachtwoord, string woonplaats, string emailadres) : base(nickname, inlognaam, wachtwoord, woonplaats, emailadres)
        {
            Nickname = nickname;
            Inlognaam = inlognaam;
            Wachtwoord = wachtwoord;
            Woonplaats = woonplaats;
            Emailadres = emailadres;
        }
        public Beheerder(int id, string nickname, string inlognaam, string wachtwoord, string woonplaats, string emailadres) : base(id, nickname, inlognaam, wachtwoord, woonplaats, emailadres)
        {
            ID = id;
            Nickname = nickname;
            Inlognaam = inlognaam;
            Wachtwoord = wachtwoord;
            Woonplaats = woonplaats;
            Emailadres = emailadres;
        }
    }
}