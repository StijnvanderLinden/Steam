using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Steam.Models;

namespace Steam.Context
{
    public interface IBestelling
    {
        void AddBestelling(Bestelling bestelling);
    }
}