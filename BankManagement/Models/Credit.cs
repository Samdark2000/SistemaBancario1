using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public class Credit
    {
        public int CreditId { get; set; }
        [Display(Name = "Monto")]
        public decimal MontantCredit { get; set; }
        [Display(Name = " Para pagar ")]
        public int Planification { get; set; }

        [Display(Name = "Pago Mensual")]
        public decimal PayementMonsuel { get; set; }
        
        [Display(Name = "Cliente")]
        public int ClienteID { get; set; }
        public Cliente Client { get; set; }
    }
}
