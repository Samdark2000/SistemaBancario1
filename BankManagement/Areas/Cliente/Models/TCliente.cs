using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Areas.Cliente.Models
{
    public class TCliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Direccion { get; set; }

        // public virtual ICollection<Cuenta> Cuentas { get; set; }
    }
}
