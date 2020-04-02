using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Cliente2.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        
        public string Solicitud { get; set; }

   
    }
}
