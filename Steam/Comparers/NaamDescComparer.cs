using Steam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam.Comparers
{
    public class NaamDescComparer : IComparer<Game>
    {
        public int Compare(Game x, Game y)
        {
            return y.Naam.CompareTo(x.Naam);
        }
    }
}