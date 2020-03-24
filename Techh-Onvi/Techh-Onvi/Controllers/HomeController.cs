using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Techh_Onvi.Models;

namespace Techh_Onvi.Controllers
{
    public class HomeController : Controller
    {
        IServiceProvider _serviceProvider;
        private readonly ILogger<HomeController> _logger;
        public HomeController(IServiceProvider serviceProvider, ILogger<HomeController>logger)
        {
           // _serviceProvider = serviceProvider;
            _logger = logger;
        }
      //  private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public  IActionResult Index()
        {
           // await CreateRolesIAsync(_serviceProvider);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        private async Task CreateRolesIAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            String[] rolesName = { "Admin", "Clientes" };
            foreach(var item in rolesName)
            {
                var roleExist = await roleManager.RoleExistsAsync(item);

                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(item));
                }

                var user = await userManager.FindByIdAsync("ce2a1129-6eea-4fbd-9408-589a40c319a7");

                await userManager.AddToRoleAsync(user, "Admin");

            }
        }
    }
}
