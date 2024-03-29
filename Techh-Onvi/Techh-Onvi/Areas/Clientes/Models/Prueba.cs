﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Techh_Onvi.Areas.Clientes.Models
{
    public class Prueba
    {
        [Key]
        public int ClienteID { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]

        public string Cedula { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]

        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Direccion { get; set; }

        public Boolean Estado { get; set; } = true;
    }
}
