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

        public DbSet<SenacLojas.Models.Product> Product { get; set; } = default!;

        public DbSet<SenacLojas.Models.Department>? Department { get; set; }
    }
}
