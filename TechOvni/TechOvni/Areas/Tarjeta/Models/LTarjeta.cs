using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechOvni.Data;
using TechOvni.Models;

namespace TechOvni.Areas.Tarjeta.Models
{
 
    public class LTarjeta
    {
        private ApplicationDbContext context;
        private IWebHostEnvironment environment;
        public LTarjeta(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
           
        }

        public IdentityError RegistrarCurso(DataPaginador<Ttarjeta> model)
        {
            IdentityError identityError;

            try
            {

                //var curso = new Ttarjeta
                //{
                //    Num_Tarjeta = model.Input,
                //    descripcion = model.Input.descripcion,
                //    horas = model.Input.horas,
                //    costo = model.Input.costo,
                //    estado = model.Input.estado,
                //    Imagen = imageByte,
                //    CategoriaID = model.Input.CategoriaID
                //};
                //context.Add(curso);
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
