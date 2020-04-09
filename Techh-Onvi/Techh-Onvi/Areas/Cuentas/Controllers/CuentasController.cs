using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Techh_Onvi.Areas.Clientes.Models;
using Techh_Onvi.Areas.Cuentas.Models;
using Techh_Onvi.Data;
using Techh_Onvi.Models;

namespace Techh_Onvi.Areas.Cuentas.Controllers
{
    [Area("Cuentas")]
    [Authorize(Roles = "Admin")]
    public class CuentasController : Controller
    {
        private LCuenta _cuenta;
        private LClientes lcliente;
        private SignInManager<IdentityUser> _signInManager;
        private static DataPaginador<TCuentas> models;
        private static IdentityError identityError;
        private IWebHostEnvironment _hostingEnviroment;
        private ApplicationDbContext _context;

        public CuentasController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager, IWebHostEnvironment environment, IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnviroment = hostingEnvironment;
            _signInManager = signInManager;
            lcliente = new LClientes(context);
            _cuenta = new LCuenta(context, environment);
        }

        public IActionResult Cuentas(int id, String Search, int Registros)
        {
            if (_signInManager.IsSignedIn(User))
            {
                Object[] objects = new Object[3];

                var data = _cuenta.getTCuentas(Search);

                if(0 < data.Count)
                {
                    var url = Request.Scheme + "://" + Request.Host.Value;
                    objects = new LPaginador<TCuentas>().paginador(data, id, Registros, "Cuentas", "Cuentas", "Cuentas", url);
                }
                else
                {
                    objects[0] = "No hay datos que mostrar";
                    objects[1] = "No hay datos que mostrar";
                    objects[2] = new List<TCuentas>();

                }

                models = new DataPaginador<TCuentas>
                {
                    List = (List<TCuentas>)objects[2],
                    Pagi_info = (string)objects[0],
                    Pagi_navegacion = (string)objects[1],
                    
                    
                    Clientes = lcliente.GetTClientes(),
                    Input = new TCuentas()
                };

                if(identityError != null)
                {
                    models.Pagi_info = identityError.Description;
                    identityError = null;
                }

                return View(models);
            }
            else
            {
                return Redirect("/Home/Index");
            }



        }
        [HttpPost]
        public string GetCuentas(DataPaginador<TCuentas> model)
        {
            if (model.Input.Numero_Cuenta != null  && model.Input.ClienteID > 0)
            {
                var data = _cuenta.RegistrarCuentas(model);

                return JsonConvert.SerializeObject(data);


         

            }
            else
            {
                
                return " Llene los campos";
            }


        }

        public IActionResult updateEstado(int id)
        {
            identityError = _cuenta.UpdateEstado(id);
            return Redirect("/Cuentas/Cuentas?area=Cuentas");
        }
        [HttpPost]

        public String EliminarCuenta(int CuentaID)
        {
            identityError = _cuenta.DeleteCuenta(CuentaID);
            return JsonConvert.SerializeObject(identityError);
        }

        public async Task<IActionResult> Export()
        {
            var list = new List<String[]>();
            if (!models.List.Equals(0))
            {
                foreach (var item in models.List)
                {
                    String[] listData =
                    {
                        
                        item.CuentaID.ToString(),
                        item.Numero_Cuenta,
                        item.Estado.ToString(),
                        item.ClienteID.ToString(),
                    };
                    list.Add(listData);
                }

            }
            String[] title = { "ID", "Numero de Cuenta", "Estado", "Clientes" };
            var export = new ExportData(_hostingEnviroment, list, title, "Cuentas.xlsx", "Cuentas");
            return await export.ExportExcelAsync();
        }

    }
}
    
