using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Steam.Models;
using Steam.Context;

namespace Steam.Repositories
{
    public class SubcategorieRepository
    {
        ISubcategorie context;
        public SubcategorieRepository(ISubcategorie context)
        {
            this.context = context;
        }
    }
}