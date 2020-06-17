using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ThermoDataStore
{
    public class ThermoDataContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public ThermoDataContext(DbContextOptions<ThermoDataContext> options) : base(options)
        {

        }

    }


    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }

    }
}
