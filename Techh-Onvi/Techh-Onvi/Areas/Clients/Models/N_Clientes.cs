using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Techh_Onvi.Areas.Clients.Models
{
    public class N_Clientes
    {
        [Key]
        public int Id { get; set; }
        

        [Display(Name ="Nombre")]
        public string Nombre { get; set; }
        [Column("varchar(50)")]

        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Column("varchar(50)")]

        public string Solicitud { get; set; }
    }
}
