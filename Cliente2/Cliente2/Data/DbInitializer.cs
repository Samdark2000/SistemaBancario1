using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cliente2.Models;
using Microsoft.AspNetCore.Http;
namespace Cliente2.Data
{
    public class DbInitializer
    {
        public static void Initialize (Cliente2Context context)
        {
            context.Database.EnsureCreated();

            if (context.Cliente.Any())
            {
                return;
            }
            var Clientes = new Cliente[]
            {
                new Cliente{Nombre ="Samuel", Apellido = "Encarnacion",Solicitud ="Targeta" },
                new Cliente{Nombre ="Roman", Apellido = "Alcantara" , Solicitud ="Targeta"}
            };
            foreach (Cliente c in Clientes)
            {
                context.Cliente.Add(c);
            }
            context.SaveChanges();
        }
    }
}
