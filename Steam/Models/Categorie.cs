using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam.Models
{
    public class Categorie : IComparable<Categorie>
    {
        public int ID { get; set; }
        public string Genre { get; set; }
        public Categorie(int id, string genre)
        {
            ID = id;
            Genre = genre;
        }

        public int CompareTo(Categorie other)
        {
            throw new NotImplementedException();
        }
    }
}