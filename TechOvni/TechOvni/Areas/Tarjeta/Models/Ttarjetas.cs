using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechOvni.Areas.Cuenta.Models;

namespace TechOvni.Areas.Tarjeta.Models
{
    public class Ttarjetas
    {
        [Key]
        public int TarjetaID { get; set; }

        public int Num_Tarjeta { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de expiracion")]
        public DateTime DateOuverture { get; set; }

        public int CVV { get; set; }

        public Boolean estado { get; set; }

        public ICollection<TCuenta> cuenta { get; set; }
    }
}
