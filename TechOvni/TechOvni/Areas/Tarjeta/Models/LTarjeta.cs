using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechOvni.Data;
using TechOvni.Models;

namespace TechOvni.Areas.Tarjeta.Models
{
 
    public class LTarjeta
    {
        private ApplicationDbContext context;
        private IWebHostEnvironment environment;

        public LTarjeta(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IdentityError RegistrarCliente(Ttarjetas cliente)
        {
            IdentityError identityError;

            try
            {
                if (cliente.TarjetaID.Equals(0))
                {
                    context.Add(cliente);
                }
                else
                {
                    context.Update(cliente);
                }


                context.SaveChanges();
                identityError = new IdentityError { Code = "Done" };
            }
            catch (Exception e)
            {
                identityError = new IdentityError
                {
                    Code = "Error",
                    Description = e.Message
                };



            }

            return identityError;
        }
        public List<Ttarjetas> getTCliente(string valor)
        {
            List<Ttarjetas> listCategoria;

            if (valor == null)
            {
                listCategoria = context._Ttarjeta.ToList();
            }
            else
            {
                listCategoria = context._Ttarjeta.Where(c => c.Num_Tarjeta.StartsWith(valor)).ToList();
            }
            return listCategoria;
        }

        internal IdentityError UpdateEstado(int id)
        {
            IdentityError identityError;

            try
            {
                var cliente = context._Ttarjeta.Where(c => c.TarjetaID.Equals(id)).ToList().ElementAt(0);
                cliente.estado = cliente.estado? false : true;
                int data = Convert.ToInt16("a");
                context.Update(cliente);
                context.SaveChanges();
                identityError = new IdentityError { Description = "Done" };
            }
            catch (Exception e)
            {
                identityError = new IdentityError
                {
                    Code = "Error",
                    Description = e.Message
                };
            }
            return identityError;
        }

        internal IdentityError DeleteCategoria(int tarjetaID)
        {
            IdentityError identityError;

            try
            {
                var tarjeta = new Ttarjetas
                {
                    TarjetaID = tarjetaID
                };

                context.Remove(tarjeta);
                context.SaveChanges();

                identityError = new IdentityError { Description = "Done" };



            }
            catch (Exception e)
            {
                identityError = new IdentityError
                {
                    Code = "Error",
                    Description = e.Message
                };
            }
            return identityError;
        }
    }
}
