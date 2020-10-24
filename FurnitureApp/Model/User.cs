using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureApp.Model
{
    public class User
    {
        public string LastName { get; set; }
        public string FirstAndMiddleName { get; set; }
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
