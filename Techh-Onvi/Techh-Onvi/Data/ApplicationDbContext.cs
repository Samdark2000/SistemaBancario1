using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Techh_Onvi.Areas.Clientes.Models;
using Techh_Onvi.Areas.Clients.Models;
using Techh_Onvi.Areas.Cuentas.Models;
using Techh_Onvi.Models;

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
        public DbSet<Prueba> _prueba { get; set; }

        public DbSet<N_Clientes> _Clientes { get; set; }
        public DbSet<XClientes> _xclients { get; set; }
        public DbSet<ImageCrudClass> Saveimg { get; set; }
        public DbSet<Trasanction> _Trasanction { get; set; }

    }
}
