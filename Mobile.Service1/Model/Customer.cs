using Mobile.Domain1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Service1.Model
{
    public class Customer 
    {
       
        public int Id { get; set; }

      
        public string? CustomerName { get; set; }

      
      
        public string? Email { get; set; }

        //public string Password { get; set; }

        //public long PhoneNumber { get; set; }

        //public string Address { get; set; }
    }
}
