using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techh_Onvi.Data;
using Techh_Onvi.Models;

namespace Techh_Onvi.Areas.Cuentas.Models
{
    public class LCuenta
    {
        private ApplicationDbContext context;
        private IWebHostEnvironment environment;
        

        public LCuenta(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
            
        }

        public IdentityError RegistrarCuentas(DataPaginador<TCuentas> model)
        {
            IdentityError identityError;

            try
            {

                if (model.Input.CuentaID.Equals(0))
                {
                    var cuentas = new TCuentas
                    {
                        Numero_Cuenta = model.Input.Numero_Cuenta,
                        Estado = model.Input.Estado,
                        ClienteID = model.Input.ClienteID
                    };
                    context.Add(cuentas);
                    context.SaveChanges();

                }
                else
                {
                    var cuenta = new TCuentas
                    {
                        CuentaID = model.Input.CuentaID,
                        Numero_Cuenta = model.Input.Numero_Cuenta,
                        Estado = model.Input.Estado,
                        ClienteID = model.Input.ClienteID
                    };
                    context.Update(cuenta);
                    context.SaveChanges();
                }


                
                
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

        internal List<TCuentas> getTCuentas(string search)
        {
            List<TCuentas> listCuentas;

            if(search == null)
            {
                listCuentas = context._TCuenta.ToList();
            }
            else
            {
                listCuentas = context._TCuenta.Where(c => c.Numero_Cuenta.StartsWith(search)).ToList();
            }
            return listCuentas;
        }

        internal IdentityError UpdateEstado(int id)
        {
            IdentityError identityError;

            try
            {
                var cuenta = context._TCuenta.Where(c => c.CuentaID.Equals(id)).ToList().ElementAt(0);
                cuenta.Estado = cuenta.Estado ? false : true;
                context.Update(cuenta);
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

        internal IdentityError DeleteCuenta(int cuentaID)
        {
            IdentityError identityError;

            try
            {
                var cuenta = new TCuentas
                {
                    CuentaID = cuentaID
                };
                context.Remove(cuenta);
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

            return null;
        }
    }
}
