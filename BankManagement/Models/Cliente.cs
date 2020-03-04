using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankManagement.Models
{
    public class Cliente
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




  


