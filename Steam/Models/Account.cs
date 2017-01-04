using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Steam.Repositories;

namespace Steam.Models
{
    public abstract class Account
    {
        public int ID { get; set; }
        public string Nickname { get; set; }
        public string Inlognaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Woonplaats { get; set; }
        public string Emailadres { get; set; }

        public Account()
        {

        }
        public Account(string inlognaam, string wachtwoord)
        {

        }
        public Account(string nickname, string inlognaam, string wachtwoord, string woonplaats, string emailadres)
        {

        }
        public Account(int id, string nickname, string inlognaam, string wachtwoord, string woonplaats, string emailadres)
        {

        }

    }
}