using System;
using System.Collections.Generic;
using System.Text;
using BankManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Credit> Credits { get; set; }
        
        public virtual DbSet<Tarjeta> Tarjetas { get; set; }

        public virtual DbSet<Cuenta> Cuentas { get; set; }
        
    }
}
