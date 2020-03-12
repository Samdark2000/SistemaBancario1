using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechOvni.Areas.Cliente.Models;
using TechOvni.Controllers;
using TechOvni.Data;
using TechOvni.Models;

namespace TechOvni.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    [Authorize]
    public class ClienteController : Controller
    {
        private TCliente _Cliente;
        public LCliente _lCliente;
        private SignInManager<IdentityUser> _signInManager;
        private static DataPaginador<TCliente> models;

        public ClienteController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _lCliente = new LCliente(context);
        }
        public IActionResult Cliente()
        {
            if (_signInManager.IsSignedIn(User))
            {
                models = new DataPaginador<TCliente>
                {
                    Input = new TCliente()

                };

                return View(models);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            
        }
        [HttpPost]
        public string GetCliente(DataPaginador<TCliente> model)
        {

            if ( model.Input.Cedula !=null && model.Input.Nombre != null && model.Input.Apellido != null && model.Input.Telefono != null && model.Input.Direccion != null && model.Input.NumeroCuenta != null)
            {
                var data = _lCliente.RegistrarCliente(model.Input);

                return JsonConvert.SerializeObject(data);
            }
            else
            {
                return "No sea Imbecil, Llene los campos";
            }
        }

    }
}