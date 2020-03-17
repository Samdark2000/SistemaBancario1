using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechOvni.Areas.Tarjeta.Models;
using TechOvni.Data;
using TechOvni.Models;

namespace TechOvni.Areas.Tarjeta.Controllers
{
    public class TarjetaController : Controller
    {
        //private LTarjeta _Tarjeta;
        //private LCategorias lCategorias;
        //private SignInManager<IdentityUser> _signInManager;
        //private static DataPaginador<TCursos> models;
        //private static IdentityError identityError;
        //private ApplicationDbContext _context;

        //public CursosController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager, IWebHostEnvironment environment)
        //{
        //    _signInManager = signInManager;
        //    lCategorias = new LCategorias(context);
        //    _cursos = new LCursos(context, environment);
        //}

        //public IActionResult Tarjeta()
        //{
        //    if (_signInManager.IsSignedIn(User))
        //    {
        //        models = new DataPaginador<Ttarjeta>
        //        {
        //            Categoria = lCategorias.getTCategoria(),
        //            Input = new TCursos()
        //        };

        //        return View(models);
        //    }
        //    else
        //    {
        //        return Redirect("/Home/Index");
        //    }
        //}
    }
}