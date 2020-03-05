using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace BankManagement.Models

{
    public enum TypeCompte
    {
        Ahorro,
        Actual,
        Profesional
    }

    public class Cuenta
    {
       [Key]
        public int CuentaID { get; set; }

        [Display(Name = "Nombre del cliente:")]
        public int ClienteID { get; set; }

        public TypeCompte? Type { get; set; }

        [Display(Name = "Saldo")]
        public decimal SaldoBase { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha")]
        public DateTime Fecha_Apertura { get; set; }

        //public virtual Banque Banque { get; set; }
        public virtual Cliente Client { get; set; }
       // public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<Credit> Credits { get; set; }
    }

}

