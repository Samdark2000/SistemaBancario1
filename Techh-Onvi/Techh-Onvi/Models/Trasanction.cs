using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Techh_Onvi.Models
{
    public class Trasanction
    {
        [Key]
        public int TransactionId { get; set; }
        [MaxLength(12)]
        [Display(Name ="Numero de cuenta")]
        [Required(ErrorMessage ="El campo es obligatorio")]
        public string AccountNumber { get; set; }
        [Display(Name = "Nombre de beneficiario")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Beneficiario { get; set; }
        [Display(Name = "Nombre del banco")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string BankName { get; set; }
        [Display(Name = "Swift Code")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string SWIFTCode { get; set; }

        public int Monto { get; set; }
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString ="{0: MM/dd/yyyy}")]
        public DateTime date { get; set; }
    }
}
