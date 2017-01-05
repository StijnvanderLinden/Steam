using Steam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam.Comparers
{
    public class PrijsDescComparer : IComparer<Game>
    {
        public int Compare(Game x, Game y)
        {
            return y.Prijs.CompareTo(x.Prijs);
        }
    }
}