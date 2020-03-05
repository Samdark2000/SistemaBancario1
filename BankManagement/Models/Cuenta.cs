using System;
using System.ComponentModel.DataAnnotations;

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
        public int CompteId { get; set; }

        [Display(Name = "Cliente")]
        public int ClientId { get; set; }

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
       // public virtual ICollection<Credit> Credits { get; set; }
    }

}

