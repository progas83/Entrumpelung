using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Entrumpelung.Models
{
    public class InfoContext : DbContext
    {
       
        public InfoContext():base("KlassenConnectionR")
        {

        }


        public DbSet<CustomerReview> CustomerReviews { get; set; }
      //  public DbSet<User> Users { get; set; }
      //  public DbSet<City> Cities { get; set; }
    }
}