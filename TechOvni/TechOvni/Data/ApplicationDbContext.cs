using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechOvni.Areas.Cliente.Models;
using TechOvni.Areas.Cuenta.Models;
using TechOvni.Areas.Tarjeta.Models;

namespace TechOvni.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TCliente> _TCliente { get; set; }
        public DbSet<TCuenta> _TCuenta { get; set; }
        public DbSet<Ttarjetas> _Ttarjeta { get; set; }
    }
}
