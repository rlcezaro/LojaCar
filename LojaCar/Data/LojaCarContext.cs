using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LojaCar.Models;

namespace LojaCar.Data
{
    public class LojaCarContext : DbContext
    {
        public LojaCarContext (DbContextOptions<LojaCarContext> options)
            : base(options)
        {
        }

        public DbSet<LojaCar.Models.Cliente> Cliente { get; set; } = default!;

        public DbSet<LojaCar.Models.Vendedor>? Vendedor { get; set; }

        public DbSet<LojaCar.Models.Carro>? Carro { get; set; }

        public DbSet<LojaCar.Models.Nota>? Nota { get; set; }
    }
}
