using Microsoft.EntityFrameworkCore;
using Paraglider.DAL.Models;
using System;

namespace Paraglider.DAL
{
    public class ParagliderContext : DbContext
    {
        public ParagliderContext(DbContextOptions<ParagliderContext> options) : base(options)
        {

        }
        public DbSet<Driver> Drivers { get; set; }
    }
}
