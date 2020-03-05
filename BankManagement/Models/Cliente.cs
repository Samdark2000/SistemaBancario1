using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }
        [Required(ErrorMessage ="Debe Ingresar sus datos")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe Ingresar sus datos")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Debe Ingresar sus datos")]
        public string  Direccion { get; set; }
    }
}
