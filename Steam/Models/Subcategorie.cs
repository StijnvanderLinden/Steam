using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam.Models
{
    public class Subcategorie
    {
        public int ID { get; set; }
        public string Genre { get; set; }
        public Subcategorie(int id, string genre)
        {
            ID = id;
            Genre = genre;
        }
    }
}