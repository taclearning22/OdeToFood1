using Microsoft.EntityFrameworkCore;
using OdeToFood1.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood1.Data
{
    public class OdeToFood1DbContext : DbContext
    {

        public OdeToFood1DbContext(DbContextOptions<OdeToFood1DbContext> options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
