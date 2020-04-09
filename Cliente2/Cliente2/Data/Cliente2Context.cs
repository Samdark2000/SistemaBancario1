using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cliente2.Models;

namespace Cliente2.Data
{
    public class Cliente2Context : DbContext
    {
        public Cliente2Context (DbContextOptions<Cliente2Context> options)
            : base(options)
        {
        }

        public DbSet<Cliente2.Models.Cliente> Cliente { get; set; }
    }
}
