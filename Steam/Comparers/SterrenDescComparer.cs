using Steam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam.Comparers
{
    public class SterrenDescComparer : IComparer<Game>
    {
        public int Compare(Game x, Game y)
        {
            return x.Sterren.CompareTo(y.Sterren);
        }
    }
}