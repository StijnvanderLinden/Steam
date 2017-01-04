using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Steam.Models;
using Steam.Context;

namespace Steam.Repositories
{
    public class UitgeverRepository
    {
        IUitgever context;
        public UitgeverRepository(IUitgever context)
        {
            this.context = context;
        }

        public Uitgever GetUitgeverByID(int ID)
        {
            return context.GetUitgeverByID(ID);
        }
    }
}