using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechOnvi_Cliente.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Column("nvarchar(250)")]


        public string Nombre { get; set; }
        [Column("varchar(50)")]


        public string Apellido { get; set; }
        [Column("varchar(50)")]

        public string Solicitud { get; set; }

    }
}
