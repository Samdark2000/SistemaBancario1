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
        public static IdentityError identityError = null;

        public ClienteController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _lCliente = new LCliente(context);
        }
        public IActionResult Cliente(int id, String Search, int Registros)
        {
            if (_signInManager.IsSignedIn(User))
            {
                Object[] objects = new Object[3];
                var data = _lCliente.getTCliente(Search);

                if (0 < data.Count)
                {
                    var url = Request.Scheme + "://" + Request.Host.Value;
                    objects = new LPaginador<TCliente>().paginador(_lCliente.getTCliente(Search)
                       , id, Registros, "Cliente", "Cliente", "Cliente", url);

                }
                else
                {
                    objects[0] = "No hay datos que mostrar";
                    objects[1] = "No hay datos que mostrar";
                    objects[2] = new List<TCliente>();
                }




                models = new DataPaginador<TCliente>
                {
                    List = (List<TCliente>)objects[2],
                    Pagi_info = (string)objects[0],
                    Pagi_navegacion = (string)objects[1],

                    Input = new TCliente()
                };

                if (identityError != null)
                {
                    models.Pagi_info = identityError.Description;
                    identityError = null;
                }

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
                return " Llene los campos";
            }
        }

        [HttpPost]

        public IActionResult UpdateEstado(int id)
        {
            identityError = _lCliente.UpdateEstado(id);
            return Redirect("/Cliente/Cliente?area=Cliente");
        }
        [HttpPost]
        public string EliminarCategoria(int clienteID)
        {
            identityError = _lCliente.DeleteCategoria(clienteID);
            return JsonConvert.SerializeObject(identityError);
        }

    }
}