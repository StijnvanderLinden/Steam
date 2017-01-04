using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Steam.Models;
using Steam.Repositories;
using Steam.Context;

namespace Steam.Models
{
    public class Reviews
    {
        ReviewRepository repo = new ReviewRepository(new ReviewSQL());
        public Reviews()
        {

        }
    }
}