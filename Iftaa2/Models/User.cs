using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Iftaa2.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="Enter User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Pelase Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool isActive { get; set; }
    }
}
