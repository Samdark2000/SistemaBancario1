using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechOvni.Areas.Cliente.Models;
using TechOvni.Areas.Tarjeta.Models;

namespace TechOvni.Areas.Cuenta.Models
{
    public class TCuenta
    {
        [Key]
        public int CuentaID { get; set; }

        public int ClienteID { get; set; }

        public TCliente cliente { get; set; }

        public int TarjetaID { get; set; }
        
        public Ttarjetas tarjeta { get; set; }
       
    }
}
