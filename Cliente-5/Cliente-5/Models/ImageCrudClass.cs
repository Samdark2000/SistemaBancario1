using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Cliente_5.Models
{
    public class ImageCrudClass
    {
        [Key]
        public int Imgid { get; set; }
        public string Imgname { get; set; }
        public string Imgpath { get; set; }
    }
}
