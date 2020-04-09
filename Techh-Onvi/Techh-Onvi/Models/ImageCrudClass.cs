using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Techh_Onvi.Models
{
    public class ImageCrudClass
    {
        [Key]
        [Display(Name ="Nro Archivo")]
        public int Imgid { get; set; }
        [Display(Name =" Nombre del Archivo")]
        public string Imgname { get; set; }
        public string Imgpath { get; set; }
    }
}
