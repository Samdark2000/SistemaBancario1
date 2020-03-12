using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechOvni.Areas.Cuenta.Models;

namespace TechOvni.Areas.Cliente.Models
{
    public class TCliente
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
        [Display(Name ="Numero de cuenta")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string NumeroCuenta { get; set; }
        public Boolean Estado { get; set; } = true;

        public ICollection<TCuenta> cuenta { get; set; }
    }
}
