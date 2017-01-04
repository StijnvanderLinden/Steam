using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam.Models
{
    public class Uitgever
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Emailadres { get; set; }
        public Uitgever(int id)
        {
            ID = id;
        }
        public Uitgever(int id, string naam, string emailadres)
        {
            ID = id;
            Naam = naam;
            Emailadres = emailadres;
        }
    }
}