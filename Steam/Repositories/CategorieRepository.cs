using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Steam.Models;
using Steam.Context;

namespace Steam.Repositories
{
    public class CategorieRepository
    {
        ICategorie context;
        public CategorieRepository(ICategorie context)
        {
            this.context = context;
        }
    }
}