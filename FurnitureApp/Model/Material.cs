using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureApp.Model
{
    public class Material
    {
        [Key]
        public string Article { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Length { get; set; }
        public string Count { get; set; }
        public string Type_of_material { get; set; }
        public string Purchase_price { get; set; }
        public string GOST { get; set; }
        public string Quality { get; set; }
        public string Main_supplier { get; set; }
    }
}
