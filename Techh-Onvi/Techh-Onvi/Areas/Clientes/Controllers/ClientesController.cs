using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Techh_Onvi.Areas.Clientes.Models;
using Techh_Onvi.Controllers;
using Techh_Onvi.Data;
using Techh_Onvi.Models;

namespace Techh_Onvi.Areas.Clientes.Controllers
{
    [Area("Clientes")]
    [Authorize(Roles ="Admin")]
    public class ClientesController : Controller
    {
        private TClientes _Cliente;
        public LClientes _lCliente;
        private SignInManager<IdentityUser> _signInManager;
        private static DataPaginador<TClientes> models;
        public static IdentityError identityError = null;

        public ClientesController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _lCliente = new LClientes(context);
        }
        public IActionResult Clientes(int id, String Search, int Registros)
        {
            if (_signInManager.IsSignedIn(User))
            {
                Object[] objects = new Object[3];
                var data = _lCliente.getTCliente(Search);

                if (0 < data.Count)
                {
                    var url = Request.Scheme + "://" + Request.Host.Value;
                    objects = new LPaginador<TClientes>().paginador(_lCliente.getTCliente(Search)
                       , id, Registros, "Clientes", "Clientes", "Clientes", url);

                }
                else
                {
                    objects[0] = "No hay datos que mostrar";
                    objects[1] = "No hay datos que mostrar";
                    objects[2] = new List<TClientes>();
                }




                models = new DataPaginador<TClientes>
                {
                    List = (List<TClientes>)objects[2],
                    Pagi_info = (string)objects[0],
                    Pagi_navegacion = (string)objects[1],

                    Input = new TClientes()
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
        public string GetCliente(DataPaginador<TClientes> model)
        {

            if (model.Input.Cedula != null && model.Input.Nombre != null && model.Input.Apellido != null && model.Input.Telefono != null && model.Input.Direccion != null)
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
            return Redirect("/Clientes/Clientes?area=Clientes");
        }

        [HttpPost]
        public string EliminarCliente(int clienteID)
        {
            identityError = _lCliente.DeleteCliente(clienteID);
            return JsonConvert.SerializeObject(identityError);
        }

    }
}