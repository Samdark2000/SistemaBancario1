using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Techh_Onvi.Areas.Clientes.Models;
using Techh_Onvi.Areas.Cuentas.Models;

namespace Techh_Onvi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

         public DbSet<TClientes> _TCliente { get; set; }
        public DbSet<TCuentas> _TCuenta { get; set; }
    }
}
