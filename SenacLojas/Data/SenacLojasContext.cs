using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SenacLojas.Models;

namespace SenacLojas.Data
{
    public class SenacLojasContext : DbContext
    {
        public SenacLojasContext (DbContextOptions<SenacLojasContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; } = default!;

        public DbSet<Department>? Department { get; set; }
        public DbSet<Seller>? Seller { get; set; }
    }
}
