using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Steam.Repositories;
using Steam.Context;

namespace Steam.Models
{
    public class Uitgevers
    {
        UitgeverRepository repo = new UitgeverRepository(new UitgeverSQL());
        public Uitgevers()
        {

        }
        public Uitgever GetUitgeverByID(int ID)
        {
            return repo.GetUitgeverByID(ID);
        }

    }
}