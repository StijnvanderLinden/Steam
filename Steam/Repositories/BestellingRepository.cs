using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Steam.Models;
using Steam.Context;

namespace Steam.Repositories
{
    public class BestellingRepository
    {
        IBestelling context;

        public BestellingRepository(IBestelling context)
        {
            this.context = context;
        }

        public void AddBestelling(Bestelling bestelling)
        {
            context.AddBestelling(bestelling);
        }
    }
}