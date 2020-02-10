using Microsoft.EntityFrameworkCore;
using Paraglider.DAL.Models;
using System;

namespace Paraglider.DAL
{
    public class ParagliderContext : DbContext
    {
        DbSet<Driver> Drivers { get; set; }
    }
}
