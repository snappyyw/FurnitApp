using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureApp.Model
{
    public class Furniture
    {
        [Key]
        public string Article { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string Unit { get; set; }
        public string type_of_accessories { get; set; }
        public string Purchase_price { get; set; }
        public string Main_supplier { get; set; }
    }
}
