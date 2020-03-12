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
    }
}
