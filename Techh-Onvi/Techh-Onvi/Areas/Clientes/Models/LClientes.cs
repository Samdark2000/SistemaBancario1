using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techh_Onvi.Data;

namespace Techh_Onvi.Areas.Clientes.Models
{
    public class LClientes
    {
        private ApplicationDbContext context;

        public LClientes(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IdentityError RegistrarCliente(TClientes cliente)
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
        public List<TClientes> getTCliente(string valor)
        {
            List<TClientes> listCategoria;

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

        internal IdentityError DeleteCliente(int clienteID)
        {
            IdentityError identityError;

            try
            {
                var clientes = new TClientes
                {
                    ClienteID = clienteID
                };

                context.Remove(clientes);
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

        public List<SelectListItem> GetTClientes()
        {
            var _selectList = new List<SelectListItem>();
            var cliente = context._TCliente.Where(c => c.Estado.Equals(true)).ToList();

            foreach (var item in cliente)
            {
                _selectList.Add(new SelectListItem
                {
                    Text = item.Cedula,
                    Value = item.ClienteID.ToString()
                });
            }
            return _selectList;
        }
    }
}
