using Microsoft.EntityFrameworkCore;
using ShopTARge22.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.Data
{
    public class ShopTARge22Context : DbContext
    {
        public ShopTARge22Context(DbContextOptions<ShopTARge22Context> options) : base(options) { }

        public DbSet<Spaceship> Spaceships { get; set; }
    }
}
