using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechOvni.Areas.Tarjeta.Models;
using TechOvni.Controllers;
using TechOvni.Data;
using TechOvni.Models;

namespace TechOvni.Areas.Tarjeta.Controllers
{
    [Area("Tarjeta")]
    [Authorize]
    public class TarjetaController : Controller
    {
        private Ttarjetas _Tarjeta;
        public LTarjeta lTarjeta;
        private SignInManager<IdentityUser> _signInManager;
        private static DataPaginador<Ttarjetas> models;
        public static IdentityError identityError = null;

        public TarjetaController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            lTarjeta = new LTarjeta(context);
        }
        public IActionResult Tarjeta(int id, String Search, int Registros)
        {
            if (_signInManager.IsSignedIn(User))
            {
                Object[] objects = new Object[3];
                var data = lTarjeta.getTCliente(Search);

                if (0 < data.Count)
                {
                    var url = Request.Scheme + "://" + Request.Host.Value;
                    objects = new LPaginador<Ttarjetas>().paginador(lTarjeta.getTCliente(Search)
                       , id, Registros, "Cliente", "Cliente", "Cliente", url);

                }
                else
                {
                    objects[0] = "No hay datos que mostrar";
                    objects[1] = "No hay datos que mostrar";
                    objects[2] = new List<Ttarjetas>();
                }




                models = new DataPaginador<Ttarjetas>
                {
                    List = (List<Ttarjetas>)objects[2],
                    Pagi_info = (string)objects[0],
                    Pagi_navegacion = (string)objects[1],

                    Input = new Ttarjetas()
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
    }
}