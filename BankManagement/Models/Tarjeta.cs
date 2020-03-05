using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public class Tarjeta
    {
        [Key]
        public int TarjetaID { get; set; }
        [CreditCard]
        [Display(Name ="Numero de Tarjeta")]
        public int Numero_Tarjeta {get; set;}

        public int ClienteID { get; set; }
        [Display(Name = "Tipo de tarjeta")]
        public string Tipo_Tarjetas { get; set; }
        [Display(Name = "CVV")]
        public int CVV { get; set; }

        public Boolean Estado { get; set; } = true;

        public virtual Cliente Client { get; set; }
    }
}
