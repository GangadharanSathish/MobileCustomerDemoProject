using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Domain1.Model.Authentication
{
    public class Registration
    {
        [Required(ErrorMessage ="UserName is Required")]
        public string? UserName { get; set; }

        public string? Gender { get; set; }

        [Required(ErrorMessage = "Email id is Required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }

      

  

        public long PhoneNumber { get; set; }

        public string? Address { get; set; }

    }
}
