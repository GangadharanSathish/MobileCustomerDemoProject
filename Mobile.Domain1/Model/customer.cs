using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Domain1.Model
{
    public class customer 
    {
        [Key]
        public int Id { get; set; }


        [StringLength(100, MinimumLength = 2)]
        public string? CustomerName { get; set; }

      

        public string? Gender { get; set; }

     
       public string? Email { get; set; }

        public string? Password { get; set; }

        public long PhoneNumber { get; set; }

        public string? Address { get; set; }
    }
}
