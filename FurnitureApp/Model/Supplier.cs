using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureApp.Model
{
    public class Supplier
    {
        [Key]
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Delivery_time { get; set; }
    }
}
