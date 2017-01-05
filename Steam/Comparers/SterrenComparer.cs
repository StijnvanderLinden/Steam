using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam.Models
{
    public class SterrenComparer : IComparer<Game>
    {
        public int Compare(Game x, Game y)
        {
            return y.Sterren.CompareTo(x.Sterren);
        }
    }
}