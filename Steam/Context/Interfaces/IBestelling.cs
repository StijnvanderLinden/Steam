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
        void DeleteBestelling(Bestelling bestelling);
        //List<Bestelling> GetBestellingen();
        //Bestelling GetBestellingByID(int ID);
    }
}