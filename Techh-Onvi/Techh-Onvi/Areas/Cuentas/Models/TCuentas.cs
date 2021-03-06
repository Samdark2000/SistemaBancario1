﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Techh_Onvi.Areas.Clientes.Models;

namespace Techh_Onvi.Areas.Cuentas.Models
{
    public class TCuentas
    {
        [Key]
        public int CuentaID { get; set; }
        [Display(Name ="Numero de cuenta")]
        [Required(ErrorMessage = "El Campo es obligatorio")]
        [RegularExpression(@"^[0-9]+([.][0-9]+)?$", ErrorMessage = "Solo Campos Numerico.")]
        public string Numero_Cuenta { get; set; }

        public Boolean Estado { get; set; }
        [Required(ErrorMessage = "Seleccione un Usuario")]
        [Display(Name ="Cedulas")]
        public int ClienteID { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public TClientes cliente { get; set; }
    }
}
