using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace OdeToFood.Data
{
    public class OdeToFoodDBContext : DbContext
    {
        public OdeToFoodDBContext(DbContextOptions<OdeToFoodDBContext> options)
            : base (options)
        {
        }
        public DbSet<Restaurant> Restaurants { get; set; }

}
}
