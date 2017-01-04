using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Steam.Models;
using Steam.Context;

namespace Steam.Repositories
{
    public class ReviewRepository
    {
        IReview context;
        public ReviewRepository(IReview context)
        {
            this.context = context;
        }
    }
}