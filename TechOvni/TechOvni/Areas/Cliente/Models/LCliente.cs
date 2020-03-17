using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechOvni.Data;

namespace TechOvni.Areas.Cliente.Models
{
    public class LCliente
    {
        private ApplicationDbContext context;

        public LCliente(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IdentityError RegistrarCliente(TCliente cliente)
        {
            IdentityError identityError;

            try
            {
                if (cliente.ClienteID.Equals(0))
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
        public List<TCliente> getTCliente(string valor)
        {
            List<TCliente> listCategoria;

            if (valor == null)
            {
                listCategoria = context._TCliente.ToList();
            }
            else
            {
                listCategoria = context._TCliente.Where(c => c.Nombre.StartsWith(valor)).ToList();
            }
            return listCategoria;
        }

        internal IdentityError UpdateEstado(int id)
        {
            IdentityError identityError;

            try
            {
                var cliente = context._TCliente.Where(c => c.ClienteID.Equals(id)).ToList().ElementAt(0);
                cliente.Estado = cliente.Estado ? false : true;
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

           internal IdentityError DeleteCategoria(int clienteID)
        {
            IdentityError identityError;

            try
            {
                var cliente = new TCliente
                {
                    ClienteID = clienteID
                };

                context.Remove(cliente);
                context.SaveChanges();

                identityError = new IdentityError { Description = "Done" };



            } catch(Exception e)
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
