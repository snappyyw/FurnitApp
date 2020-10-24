using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureApp.Model
{
    public class Equipment
    {
        [Key]
        public int? Marking { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Specifications { get; set; }
    }
}
